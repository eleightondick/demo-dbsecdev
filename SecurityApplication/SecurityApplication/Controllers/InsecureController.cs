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
            return View();
        }
    }
}