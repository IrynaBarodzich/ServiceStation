using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectTest.Models
{
    public class BestChemistryStudent : IBestStudent
    {

        public IEnumerable<Student> GetStudent(IEnumerable<Student> _students)
        {
            int max = _students.Max(c => c.ChemistryMark);
            return _students.Where(c => c.ChemistryMark == max);
        }

    }
}