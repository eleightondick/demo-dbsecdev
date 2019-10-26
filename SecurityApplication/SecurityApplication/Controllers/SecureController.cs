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
        private EFDbContext _context;
        public SecureController()
        {
            _context = new EFDbContext();
        }

        // GET: Secure
        public ActionResult Index()
        {
            return View();
        }
    }
}