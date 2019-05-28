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
    public class ProgramsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Programs
        public ActionResult Index()
        {
            var programs = db.programs.Include(p => p.eventt).Include(p => p.tournament);
            return View(programs.ToList());
        }

        // GET: Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name");
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,fk_tournament,fk_event")] program program)
        {
            if (ModelState.IsValid)
            {
				if (Session["TournamentId"] != null)
				{
					int d = (int)Session["TournamentId"];
					program.fk_tournament = d;
					Session.Remove("TournamentId");
					db.programs.Add(program);
					db.SaveChanges();
					return RedirectToAction("Details","Tournaments",new { id=d});
				}
            }

            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", program.fk_event);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", program.fk_tournament);
            return View(program);
        }

        // GET: Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", program.fk_event);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", program.fk_tournament);
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,fk_tournament,fk_event")] program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", program.fk_event);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", program.fk_tournament);
            return View(program);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            program program = db.programs.Find(id);
            db.programs.Remove(program);
            db.SaveChanges();
            return RedirectToAction("Index","Tournaments");
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
