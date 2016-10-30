using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectTest.Models
{
    public class BestAverageStudent: IBestStudent
    {
        public IEnumerable<Student> GetStudent(IEnumerable<Student> _students)
        {
            double max = _students.Max(c => (c.ChemistryMark+c.BiologyMark+c.ArtMark+c.MathMark)/4);
            return _students.Where(c => (c.ChemistryMark + c.BiologyMark + c.ArtMark + c.MathMark) / 4 == max);
        }
    }
}