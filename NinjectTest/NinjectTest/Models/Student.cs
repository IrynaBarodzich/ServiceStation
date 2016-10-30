using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectTest.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int MathMark { get; set; }
        public int ArtMark { set; get; }
        public int ChemistryMark { set; get; }
        public int BiologyMark { set; get; }

    }
}