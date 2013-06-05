using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoServer.DataAccessLayer;
using PhotoServer.Domain;
using RacePhotos;

namespace RacePhotos.Controllers
{   
    public class RacesController : Controller
    {
	    private IRaceDataSource context;

	    public RacesController(IRaceDataSource context)
	    {
		    this.context = context;
	    }

        //
        // GET: /Races/

        public ViewResult Index()
        {
            return View(context.Races.FindAll().Include(race => race.Distance).ToList());
        }

        //
        // GET: /Races/Details/5

        public ViewResult Details(int id)
        {
	        Race race = context.Races.FindById(id);
            return View(race);
        }

        //
        // GET: /Races/Create

        public ActionResult Create()
        {
            ViewBag.PossibleEvents = context.Events;
            ViewBag.PossibleDistances = context.Distances;
            return View();
        } 

        //
        // POST: /Races/Create

        [HttpPost]
        public ActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                context.Races.Add(race);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleEvents = context.Events;
            ViewBag.PossibleDistances = context.Distances;
            return View(race);
        }
        
        //
        // GET: /Races/Edit/5
 
        public ActionResult Edit(int id)
        {
	        Race race = context.Races.FindById(id);
            ViewBag.PossibleEvents = context.Events;
            ViewBag.PossibleDistances = context.Distances;
            return View(race);
        }

        //
        // POST: /Races/Edit/5

        [HttpPost]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
	            context.Races.AddOrUpdate(race);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleEvents = context.Events;
            ViewBag.PossibleDistances = context.Distances;
            return View(race);
        }

        //
        // GET: /Races/Delete/5
 
        public ActionResult Delete(int id)
        {
	        Race race = context.Races.FindById(id);
            return View(race);
        }

        //
        // POST: /Races/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
	        Race race = context.Races.FindById(id);
            context.Races.Remove(race);
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