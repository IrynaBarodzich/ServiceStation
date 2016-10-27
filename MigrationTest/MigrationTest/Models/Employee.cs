using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MigrationTest.Models
{
    public class Employee
    {
        public Employee()
        {
            Chiefs = new HashSet<Chief>();
        }

        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        public virtual ICollection<Chief> Chiefs { get; set; }
    }
}