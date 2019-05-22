using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSGO.Models;

namespace CSGO.Controllers
{
    public class placesController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: places
        public ActionResult Index()
        {
            var places = db.places.Include(p => p.match).Include(p => p.user);
            return View(places.ToList());
        }

        // GET: places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            place place = db.places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: places/Create
        public ActionResult Create()
        {
            ViewBag.fk_match = new SelectList(db.matches, "id", "map");
            ViewBag.fk_user = new SelectList(db.users, "id", "id");
            return View();
        }

        // POST: places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,index,fk_user,fk_match")] place place)
        {
            if (ModelState.IsValid)
            {
                db.places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_match = new SelectList(db.matches, "id", "map", place.fk_match);
            ViewBag.fk_user = new SelectList(db.users, "id", "id", place.fk_user);
            return View(place);
        }

        // GET: places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            place place = db.places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", place.fk_match);
            ViewBag.fk_user = new SelectList(db.users, "id", "id", place.fk_user);
            return View(place);
        }

        // POST: places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,index,fk_user,fk_match")] place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", place.fk_match);
            ViewBag.fk_user = new SelectList(db.users, "id", "id", place.fk_user);
            return View(place);
        }

        // GET: places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            place place = db.places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            place place = db.places.Find(id);
            db.places.Remove(place);
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
