using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityApplication.Controllers
{
    public class InsecureController : Controller
    {
        // GET: Insecure
        public ActionResult Index()
        {
            ViewBag.Message = TempData["message"]?.ToString();
            return View();
        }

        public ActionResult SqlInjection()
        {
            return View();
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