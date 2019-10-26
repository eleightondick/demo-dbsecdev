using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            if (!String.IsNullOrEmpty(TempData["message"] as String))
            {
                ViewBag.Message = (string)TempData["message"];
            }

            PeopleCompanies peopleCompanies = new PeopleCompanies(_context);
            return View(peopleCompanies);
        }

        public ActionResult Edit(int id)
        {
            PeopleCompanies peopleCompanies = new PeopleCompanies(_context);
            peopleCompanies.PersonToEdit = _context.People.FirstOrDefault(x => x.Id == id);

            if (peopleCompanies.PersonToEdit == null)
            {
                return new HttpNotFoundResult("Person, by this ID, was not found");
            }

            return View("Edit", peopleCompanies);
        }

        [HttpPost]
        public ActionResult Edit(PeopleCompanies peopleCompanies)
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
    }
}