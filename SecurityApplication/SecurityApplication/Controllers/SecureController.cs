using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityApplication.Models;

namespace SecurityApplication.Controllers
{
    public class SecureController : Controller
    {

        public SecureController()
        {

        }
        // GET: Secure
        public ActionResult Index()
        {
            return View();
        }
    }
}