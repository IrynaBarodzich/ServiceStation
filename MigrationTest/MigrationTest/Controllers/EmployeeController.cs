using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MigrationTest.Data;
using MigrationTest.Models;

namespace MigrationTest.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        private Company db = new Company();

        public ActionResult Index()
        {
            var employee = db.Employees;
            return View(employee);
        }

        public ActionResult ChiefList(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}
