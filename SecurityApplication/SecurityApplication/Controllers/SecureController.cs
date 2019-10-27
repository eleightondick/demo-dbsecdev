using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityApplication.Helpers;
using SecurityApplication.Models;

namespace SecurityApplication.Controllers
{
    public class SecureController : Controller
    {
        private EFDbContext _context;
        public SecureController()
        {
            _context = new EFDbContext();
        }

        // GET: Secure
        public ActionResult Index()
        {
            ViewBag.Message = TempData["message"]?.ToString();

            SecureHelper peopleCompanies = new SecureHelper(_context);
            return View(peopleCompanies);
        }

        public ActionResult Edit(int id)
        {
            SecureHelper peopleCompanies = new SecureHelper(_context);
            peopleCompanies.PersonToEdit = _context.People.FirstOrDefault(x => x.Id == id);

            if (peopleCompanies.PersonToEdit == null)
            {
                return new HttpNotFoundResult("Person, by this ID, was not found");
            }

            return View("Edit", peopleCompanies);
        }

        [HttpPost]
        public ActionResult Edit(SecureHelper peopleCompanies)
        {
            Person person = peopleCompanies.PersonToEdit;
            // NOTE: Most of this, in a real app, would go into the model and ideally use a graphdiff like operation to update properties
            Person p = _context.People.FirstOrDefault(x => x.Id == person.Id);

            if (p == null)
            {
                return new HttpNotFoundResult("Person, with this ID, was not found");
            }

            Company c = _context.Companies.FirstOrDefault(x => x.Id == person.Company.Id);

            if (c == null)
            {
                return new HttpNotFoundResult("Company, with provided ID, was not found");
            }

            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Company = c;

            _context.SaveChanges();

            TempData["message"] = "Person Saved";
            return RedirectToAction("Index", "Secure");
        }

        public ActionResult SqlInjection()
        {
            SecureHelper helper = new SecureHelper(_context);
            return View("SqlInjection", helper);
        }

        [HttpPost]
        public ActionResult SqlInjection(SecureHelper helper)
        {
            string sqlToExecute = "delete from People where Id = @id";

            string connectionString = _context.Database.Connection.ConnectionString;
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlToExecute, connection);
                command.Parameters.AddWithValue("@id", helper.Statement);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            //Now reload data, set attributes and reload previous view
            SecureHelper newHelper = new SecureHelper(_context);
            newHelper.ProcessedStatement = sqlToExecute;
            newHelper.RowsAffected = rowsAffected;

            return View("SqlInjection", newHelper);
        }

        public ActionResult XSS()
        {
            SecureHelper helper = new SecureHelper(_context);
            return View("XSS", helper);
        }

        [HttpPost]
        public ActionResult XSS(Helper helper)
        {
            Comment comment = new Comment()
            {
                CommentText =  helper.Comment
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("XSS", "Secure");
        }
    }
}