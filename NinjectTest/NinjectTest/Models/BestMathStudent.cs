using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectTest.Models
{
    public class BestMathStudent : IBestStudent
    {

        public IEnumerable<Student> GetStudent(IEnumerable<Student> _students)
        {
            int max = _students.Max(c => c.MathMark);
            return _students.Where(c => c.MathMark == max);
        }

    }
}