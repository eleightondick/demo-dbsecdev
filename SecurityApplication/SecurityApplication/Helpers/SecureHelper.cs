using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class SecureHelper : Helper
    {
        public Person PersonToEdit { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public SelectList CompanyList { get; set; }

        public SecureHelper() { }

        public SecureHelper(EFDbContext context) : base(context)
        {
            this.Companies = context.Companies;
            BuildSelectList();
        }

        public void BuildSelectList()
        {
            this.CompanyList = new SelectList(Companies, "Id", "Name");
        }
    }
}