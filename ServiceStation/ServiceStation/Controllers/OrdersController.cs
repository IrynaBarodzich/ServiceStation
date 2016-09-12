using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data;

namespace ServiceStation.Controllers
{
    public class OrdersController : Controller
    {
        //
        private ServiceContext db = new ServiceContext();


        public ViewResult Edit(int id)
        {
            Orders order = db.Orders.Find(id);
            return View(order);
        }


        public ViewResult Create(int id)
        {
            TempData["id"] = id;
            return View();
        }



        public ActionResult Delete(int id, bool? saveChangesError)
        {

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes.";
            }
            return View(db.Orders.Find(id));
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {

            var order = db.Orders.Find(id);
            if (TryUpdateModel(order, "",
               new string[] { "Date", "Amount", "Status"}))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Details/" + order.CarsID, "Cars");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(order);
        }


        [HttpPost]
        public ActionResult Create(Orders order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Details/" + order.CarsID, "Cars");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(order);
        }



        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = db.Orders.Find(id);
            try
            { 
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {  
                { "id", id },  
                { "saveChangesError", true } });
            }
            return RedirectToAction("Details/" + order.CarsID, "Cars");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}
