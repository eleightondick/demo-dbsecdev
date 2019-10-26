using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class PeopleCompanies
    {
        public Person PersonToEdit { get; set; }
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public SelectList CompanyList { get; set; }

        public PeopleCompanies() { }

        public PeopleCompanies(EFDbContext context)
        {
            this.People = context.People;
            this.Companies = context.Companies;
            BuildSelectList();
        }

        public void BuildSelectList()
        {
            this.CompanyList = new SelectList(Companies, "Id", "Name");
        }
    }
}