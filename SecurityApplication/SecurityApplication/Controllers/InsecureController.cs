using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityApplication.Helpers;
using SecurityApplication.Models;

namespace SecurityApplication.Controllers
{
    public class InsecureController : Controller
    {
        private readonly EFDbContext _context;

        public InsecureController()
        {
            _context = new EFDbContext();
        }

        // GET: Insecure
        public ActionResult Index()
        {
            ViewBag.Message = TempData["message"]?.ToString();
            return View();
        }

        public ActionResult SqlInjection()
        {
            InsecureHelper helper = new InsecureHelper(_context);
            return View("SqlInjection", helper);
        }

        [HttpPost]
        public ActionResult SqlInjection(InsecureHelper helper)
        {
            string sqlToExecute = "delete from People where Id = " + helper.Statement;

            string connectionString = _context.Database.Connection.ConnectionString;
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlToExecute, connection);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            
            //Now reload data, set attributes and reload previous view
            InsecureHelper newHelper = new InsecureHelper(_context);
            newHelper.ProcessedStatement = sqlToExecute;
            newHelper.RowsAffected = rowsAffected;
            
            return View("SqlInjection", newHelper);
        }

        public ActionResult XSS()
        {
            InsecureHelper helper = new InsecureHelper(_context);
            return View("XSS", helper);
        }
    }
}