using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data.Entity;
using System.Data;

namespace ServiceStation.Controllers
{
    public class CarsController : Controller
    {


        private ServiceContext db = new ServiceContext();



        public ViewResult Details(int id)
        {
            Cars car = db.Cars.Find(id);
            return View(car);
        }


        public ViewResult Edit(int id)
        {
            Cars car = db.Cars.Find(id);
            return View(car);
        }


        public ViewResult Create(int id)
        {
       //     Session["id"] = id;
            TempData["id"] = id;
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View(db.Cars.Find(id));
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {

            var car = db.Cars.Find(id);
            if (TryUpdateModel(car, "",
               new string[] { "Make", "Model", "Year", "VIN" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Details/"+car.ClientsID,"Clients");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(car);
        }


        [HttpPost]
        public ActionResult Create(Cars car)
        {
         //   car.ClientsID = (int)Session["id"];
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                    return RedirectToAction("Details/" + car.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(car);
        }



        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars car = db.Cars.Find(id);
            try
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }
            return RedirectToAction("Details/" + car.ClientsID, "Clients");
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
