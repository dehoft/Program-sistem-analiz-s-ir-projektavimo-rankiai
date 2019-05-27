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
    public class TournamentsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Tournaments
        public ActionResult Index()
        {
            var tournaments = db.tournaments.Include(t => t.evaluation).Include(t => t.eventt).Include(t => t.match).Include(t => t.program);
            return View(tournaments.ToList());
        }

        // GET: Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description");
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name");
            ViewBag.fk_match = new SelectList(db.matches, "id", "map");
            ViewBag.fk_program = new SelectList(db.programs, "id", "name");
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,type,fk_event,fk_match,fk_evaluation,fk_program,start_time,end_time")] tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", tournament.fk_evaluation);
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", tournament.fk_event);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", tournament.fk_match);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", tournament.fk_program);
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", tournament.fk_evaluation);
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", tournament.fk_event);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", tournament.fk_match);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", tournament.fk_program);
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,fk_event,fk_match,fk_evaluation,fk_program,start_time,end_time")] tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", tournament.fk_evaluation);
            ViewBag.fk_event = new SelectList(db.eventts, "id", "name", tournament.fk_event);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", tournament.fk_match);
            ViewBag.fk_program = new SelectList(db.programs, "id", "name", tournament.fk_program);
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tournament tournament = db.tournaments.Find(id);
            db.tournaments.Remove(tournament);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
		// GET: Tournaments/Register/5
		public ActionResult Register(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return RedirectToAction("Create", "Matches", new { id = id });
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
