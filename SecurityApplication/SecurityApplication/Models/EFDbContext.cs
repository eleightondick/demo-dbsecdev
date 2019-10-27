using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecurityApplication.Models
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string connString) : base(connString)
        {

        }

        public EFDbContext()
        {

        }

        public virtual DbSet<Person> People { get; set; }
        public virtual  DbSet<Company> Companies { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}