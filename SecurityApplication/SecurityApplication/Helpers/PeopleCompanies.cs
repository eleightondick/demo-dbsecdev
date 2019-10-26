using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class PeopleCompanies
    {
        public IEnumerable<Person> People;
        public IEnumerable<Company> Companies;

        public PeopleCompanies(EFDbContext context)
        {
            this.People = context.People;
            this.Companies = context.Companies;
        }
    }
}