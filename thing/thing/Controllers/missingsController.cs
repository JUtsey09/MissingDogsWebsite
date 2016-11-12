using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thing.Models;

namespace thing.Controllers
{
    public class MissingsController : Controller
    {
        private MissingDogsEntities db = new MissingDogsEntities();

        // GET: missings
        public ActionResult Index()
        {
            return View(db.missings.ToList());
        }

        // GET: missings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missing missing = db.missings.Find(id);
            if (missing == null)
            {
                return HttpNotFound();
            }
            return View(missing);
        }
        // GET: missing/Found
        public ActionResult Found()
        {
            return View();
        }
        // GET: missings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: missings/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DogName,DogBreed,LastKnownLocation,ContactNumber")] missing missing)
        {
            if (ModelState.IsValid)
            {
                db.missings.Add(missing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missing);
        }

        // GET: missings/Edit/5
        public ActionResult Edit(int? id)
        {
            // todo: update this thing to do some other thing 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missing missing = db.missings.Find(id);
            if (missing == null)
            {
                return HttpNotFound();
            }
            return View(missing);
        }

        // POST: missings/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DogName,DogBreed,LastKnownLocation,ContactNumber")] missing missing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missing);
        }

        // GET: missings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missing missing = db.missings.Find(id);
            if (missing == null)
            {
                return HttpNotFound();
            }
            return View(missing);
        }

        // POST: missings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            missing missing = db.missings.Find(id);
            db.missings.Remove(missing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
