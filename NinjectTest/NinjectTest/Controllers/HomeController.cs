using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjectTest.Models;

namespace NinjectTest.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        //
        // GET: /Home/
        List<Student> students = new List<Student> {
            new Student(){StudentID = 1, Name = "A. Popov", MathMark = 8, ArtMark = 6, ChemistryMark = 7, BiologyMark = 9},
            new Student(){StudentID = 2, Name = "M. Nosov", MathMark = 7, ArtMark = 9, ChemistryMark = 5, BiologyMark = 8},
            new Student(){StudentID = 3, Name = "A. Belova", MathMark = 10, ArtMark = 8, ChemistryMark = 4, BiologyMark = 9},
            new Student(){StudentID = 4, Name = "D. Ostapchik", MathMark = 8, ArtMark = 5, ChemistryMark = 10, BiologyMark = 8},
            new Student(){StudentID = 5, Name = "S. Rostov", MathMark = 7, ArtMark = 10, ChemistryMark = 8, BiologyMark = 6},
            new Student(){StudentID = 6, Name = "N. Veselov", MathMark = 6, ArtMark = 7, ChemistryMark = 9, BiologyMark = 5},
            new Student(){StudentID = 7, Name = "M. Domko", MathMark = 9, ArtMark = 4, ChemistryMark = 10, BiologyMark = 7},
            new Student(){StudentID = 8, Name = "Y. Ilkin", MathMark = 7, ArtMark = 10, ChemistryMark = 8, BiologyMark = 6},
            new Student(){StudentID = 9, Name = "O. Lapich", MathMark = 10, ArtMark = 7, ChemistryMark = 7, BiologyMark = 9},
            new Student(){StudentID = 10, Name = "L. Hromov", MathMark = 8, ArtMark = 8, ChemistryMark = 6, BiologyMark = 7}
        };

        private IBestStudent stud;
        public HomeController(IBestStudent _stud)
        {
            stud = _stud;
        }


        public ActionResult Index()
        {
            BestStudentHelper help = new BestStudentHelper(stud) { Students = students };
            IEnumerable<Student> best = help.GetBestStudent();
            return View(best);





        }
    }
}
    

