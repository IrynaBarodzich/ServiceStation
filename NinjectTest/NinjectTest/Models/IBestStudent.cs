using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NinjectTest.Models
{
    public interface IBestStudent
    {
        IEnumerable<Student> GetStudent(IEnumerable<Student> _students);
    }
}
