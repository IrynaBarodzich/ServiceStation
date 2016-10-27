using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MigrationTest.Models
{
    public class Chief
    {
        public Chief()
        {
            Employees = new HashSet<Employee>();
        }

        public int ChiefID { get; set; }
        [Required]
        public string ChiefName { get; set; }

        public string ChiefStatus { get; set; }

        public int ChiefAge { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}