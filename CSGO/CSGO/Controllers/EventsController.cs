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
    public class EventsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Events
        public ActionResult Index()
        {
            var eventts = db.eventts.Include(e => e.tournament).Include(e => e.program);
            return View(eventts.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventt eventt = db.eventts.Find(id);
            if (eventt == null)
            {
                return HttpNotFound();
            }
            return View(eventt);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name");
            ViewBag.fk_program = new SelectList(db.programs, "id", "name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,start_time,finish_time,name,fk_program,fk_tournament")] eventt eventt)
        {
            if (ModelState.IsValid)
            {
                db.eventts.Add(eventt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", eventt.fk_tournament);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", eventt.fk_program);
            return View(eventt);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventt eventt = db.eventts.Find(id);
            if (eventt == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", eventt.fk_tournament);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", eventt.fk_program);
            return View(eventt);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,start_time,finish_time,name,fk_program,fk_tournament")] eventt eventt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", eventt.fk_tournament);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", eventt.fk_program);
            return View(eventt);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventt eventt = db.eventts.Find(id);
            if (eventt == null)
            {
                return HttpNotFound();
            }
            return View(eventt);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventt eventt = db.eventts.Find(id);
            db.eventts.Remove(eventt);
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
