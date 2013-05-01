using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoServer.DataAccessLayer;

namespace RacePhotos.Controllers
{
    public class PhotosController : Controller
    {
	    private IPhotoDataSource _db;
		public PhotosController(IPhotoDataSource db)
		{
			_db = db;
		}
        //
        // GET: /Photos/

        public ActionResult List()
        {
	        var race = (string) Session["race"];
	        var station = (string) Session["station"];
			if (string.IsNullOrEmpty(race) || string.IsNullOrEmpty(station))
			{
				return RedirectToAction("List", "RacesController");
			}
            return View();
        }

		////
		//// GET: /Photos/Details/5

		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

		////
		//// GET: /Photos/Create

		//public ActionResult Create()
		//{
		//	return View();
		//}

		////
		//// POST: /Photos/Create

		//[HttpPost]
		//public ActionResult Create(FormCollection collection)
		//{
		//	try
		//	{
		//		// TODO: Add insert logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		////
		//// GET: /Photos/Edit/5

		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		////
		//// POST: /Photos/Edit/5

		//[HttpPost]
		//public ActionResult Edit(int id, FormCollection collection)
		//{
		//	try
		//	{
		//		// TODO: Add update logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		////
		//// GET: /Photos/Delete/5

		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		////
		//// POST: /Photos/Delete/5

		//[HttpPost]
		//public ActionResult Delete(int id, FormCollection collection)
		//{
		//	try
		//	{
		//		// TODO: Add delete logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
    }
}
