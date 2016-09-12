using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Data;
using ServiceStation.Models;
using System.Data;
using System.Data.Entity;


namespace ServiceStation.Controllers
{
    public class ClientsController : Controller
    {



        private ServiceContext db = new ServiceContext();

        public ViewResult Index()
        {        
            return View();
        }

        public ViewResult List(string firstName, string lastName)
        {

            var clients = db.Clients
                .Where(c => c.FirstName == firstName)
                .Where(c => c.LastName == lastName);
            return View(clients.ToList());
        }



        public ViewResult Details(int id)
        {
            Clients client = db.Clients.Find(id);
            return View(client);
        }


        public ViewResult Edit(int id)
        {
            
            Clients client = db.Clients.Find(id);
            TempData["firstName"] = client.FirstName;
            TempData["lastName"] = client.LastName;
            return View(client);
        }

        public ViewResult Create()
        {
            return View();
        }



        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {

            var client = db.Clients.Find(id);
            if (TryUpdateModel(client, "",
               new string[] { "LastName", "FirstName", "BirthDate", "Address", "Phone", "Email" }))
            {
                try
                
                {
                    client = db.Clients.Find(id);
                    db.SaveChanges();

                    return RedirectToAction("Details/"+client.ClientsID);
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(client);
        }

        [HttpPost]
        public ActionResult Create(Clients client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Details/" + client.ClientsID, "Clients");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(client);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }





    }
}
