using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SecurityApplication.Models;

namespace SecurityApplication.Helpers
{
    public class InsecureHelper : Helper
    {
        public InsecureHelper() : base() { }

        public InsecureHelper(EFDbContext context) : base(context)
        {
            Statement = "0;delete from People";
        }
    }
}