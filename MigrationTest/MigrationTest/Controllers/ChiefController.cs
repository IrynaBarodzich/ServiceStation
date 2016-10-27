using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MigrationTest.Data;

namespace MigrationTest.Controllers
{
    public class ChiefController : Controller
    {
        //
        // GET: /Chief/

        private Company db = new Company();

        public ActionResult Index()
        {
            var chief = db.Chiefs;
            return View(chief);
        }


        public ActionResult EmpList(int id)
        {
            var chief = db.Chiefs.Find(id);
            return View(chief);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
