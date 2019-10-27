using System;
using System.Collections.Generic;
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
            return View(helper);
        }

        [HttpPost]
        public ActionResult SqlInjection(string codeToExecute)
        {
            //Do injection here
            TempData["Message"] = "Data Saved";
            return RedirectToRoute("Index");
        }
    }
}