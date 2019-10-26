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
        public IEnumerable<Person> People;
        public IEnumerable<Company> Companies;
        public SelectList CompanyList;

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