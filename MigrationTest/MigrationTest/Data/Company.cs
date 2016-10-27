using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MigrationTest.Models;

namespace MigrationTest.Data
{
    public class Company: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Chief> Chiefs { get; set; }
    }
}