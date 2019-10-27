using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class InsecureHelper
    {
        public IEnumerable<Person> People { get; set; }

        [Display(Name = "Enter the \"Id\" to delete")]
        public string Statement { get; set; }

        public InsecureHelper(EFDbContext context)
        {
            People = context.People;
            Statement = "0;delete from People";
        }
    }
}