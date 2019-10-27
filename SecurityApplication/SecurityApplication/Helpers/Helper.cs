using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class Helper
    {
        [Display(Name = "Enter the \"Id\" to delete")]
        public string Statement { get; set; }
        public int RowsAffected { get; set; } = 0;
        public string ProcessedStatement { get; set; }
        public IEnumerable<Person> People { get; set; }

        public Helper() { }
        public Helper(EFDbContext context)
        {
            People = context.People;
            Statement = "0;delete from People";
        }
    }
}