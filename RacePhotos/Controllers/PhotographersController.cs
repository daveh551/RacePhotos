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
	[Authorize(Roles = "admin")]
    public class PhotographersController : Controller
    {
	    private IPhotoDataSource context;

	    public PhotographersController(IPhotoDataSource context)
	    {
		    this.context = context;
	    }

        //
        // GET: /Photographers/

        public ViewResult Index()
        {
            return View(context.Photographers.FindAll().ToList());
        }

        //
        // GET: /Photographers/Details/5

        public ViewResult Details(int id)
        {
	        Photographer photographer = context.Photographers.FindById(id);
            return View(photographer);
        }

        //
        // GET: /Photographers/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Photographers/Create

        [HttpPost]
        public ActionResult Create(Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                context.Photographers.Add(photographer);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(photographer);
        }
        
        //
        // GET: /Photographers/Edit/5
 
        public ActionResult Edit(int id)
        {
	        Photographer photographer = context.Photographers.FindById(id);
            return View(photographer);
        }

        //
        // POST: /Photographers/Edit/5

        [HttpPost]
        public ActionResult Edit(Photographer photographer)
        {
            if (ModelState.IsValid)
            {
	            context.Update(photographer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photographer);
        }

        //
        // GET: /Photographers/Delete/5
 
        public ActionResult Delete(int id)
        {
	        Photographer photographer = context.Photographers.FindById(id);
            return View(photographer);
        }

        //
        // POST: /Photographers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
	        Photographer photographer = context.Photographers.FindById(id);
            context.Photographers.Remove(photographer);
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