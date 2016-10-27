using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MigrationTest.Models;

namespace MigrationTest.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<Company>
    {
        protected override void Seed(Company context)
        {
            var employees = new List<Employee> 
            { 
                new Employee {EmployeeName= "I. Popov"}, 
                new Employee {EmployeeName= "I. Lastov"}, 
                new Employee {EmployeeName= "I. Lapin"}, 
                new Employee {EmployeeName= "I. Fomin"}, 
                new Employee {EmployeeName= "A. Popov"}, 
                new Employee {EmployeeName= "I. Petrov"} 

 };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var chiefs = new List<Chief> 
            { 
                new Chief {ChiefName= "M. Popov"}, 
                new Chief {ChiefName= "M. Lastov"}, 
                new Chief {ChiefName= "M. Lapin"}, 
                new Chief {ChiefName= "M. Fomin"}, 
                new Chief {ChiefName= "N. Popov"}, 
                new Chief {ChiefName= "M. Petrov"} 

 };
            chiefs.ForEach(s => context.Chiefs.Add(s));
            context.SaveChanges();


        } 
    }
}