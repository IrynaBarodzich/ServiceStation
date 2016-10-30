using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectTest.Models
{
    public class BestStudentHelper
    {
    private IBestStudent student;
    public BestStudentHelper(IBestStudent _student)
    {
        student = _student;
    }
    public IEnumerable<Student> Students { get; set; }
    public IEnumerable<Student> GetBestStudent()
    {
        return student.GetStudent(Students).ToList();
    }
    }
}
