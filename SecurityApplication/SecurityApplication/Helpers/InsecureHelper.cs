using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class InsecureHelper
    {
        public IEnumerable<Person> People { get; set; }
        public string Statement { get; set; }

        public InsecureHelper(EFDbContext context)
        {
            People = context.People;
        }
    }
}