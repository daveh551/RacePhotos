using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoServer.Domain;
using PhotoServer.DataAccessLayer;

namespace RacePhotos.Controllers
{   
    public class EventsController : Controller
    {
        private EFPhotoServerDataSource context = new EFPhotoServerDataSource();

        //
        // GET: /Events/

        public ViewResult Index()
        {
            return View(context.Events.FindAll().ToList());
        }

        //
        // GET: /Events/Details/5

        public ViewResult Details(int id)
        {
            Event @event = context.Events.FindById(id);
            return View(@event);
        }

        //
        // GET: /Events/Create

		[Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Events/Create

        [HttpPost]
		[Authorize(Roles = "admin")]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(@event);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(@event);
        }
        
        //
        // GET: /Events/Edit/5
 
		[Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Event @event = context.Events.FindById(id);
            return View(@event);
        }

        //
        // POST: /Events/Edit/5

		[Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                context.Update(@event);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        //
        // GET: /Events/Delete/5
 
		
		[Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Event @event = context.Events.FindById(id);
            return View(@event);
        }

        //
        // POST: /Events/Delete/5

		[Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = context.Events.FindById(id);
            context.Events.Remove(@event);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}