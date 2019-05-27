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
    public class MatchesController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.matches.Include(m => m.betting).Include(m => m.tournament).Include(m => m.ticket).Include(m => m.place).Include(m => m.ticket1).Include(m => m.team).Include(m => m.team1);
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create(int? id)
        {
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id");
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name");
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description");
            ViewBag.fk_place = new SelectList(db.places, "id", "id");
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description");
            ViewBag.fk_first_team = new SelectList(db.teams, "id", "name");
            ViewBag.fk_second_team = new SelectList(db.teams, "id", "name");
			tournament tournament = db.tournaments.Find(id);
			if(tournament==null)
				return HttpNotFound();
			DateTime date = DateTime.Now;
			TimeSpan time = new TimeSpan(12, 0, 0);
			DateTime Tdate = tournament.start_time;
			Tdate = Tdate.Subtract(time);
			if (date < Tdate)
				return View();
			else
				return RedirectToAction("Index", "Tournaments");
		}

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,start_time,map,result,is_broadcasted,is_registration_open,fk_first_team,fk_second_team,fk_tournament,fk_place,fk_betting,fk_ticket")] match match)
        {
            if (ModelState.IsValid)
            {
                db.matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", match.fk_betting);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", match.fk_tournament);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", match.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_first_team = new SelectList(db.teams, "id", "name", match.fk_first_team);
            ViewBag.fk_second_team = new SelectList(db.teams, "id", "name", match.fk_second_team);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", match.fk_betting);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", match.fk_tournament);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", match.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_first_team = new SelectList(db.teams, "id", "name", match.fk_first_team);
            ViewBag.fk_second_team = new SelectList(db.teams, "id", "name", match.fk_second_team);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,start_time,map,result,is_broadcasted,is_registration_open,fk_first_team,fk_second_team,fk_tournament,fk_place,fk_betting,fk_ticket")] match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", match.fk_betting);
            ViewBag.fk_tournament = new SelectList(db.tournaments, "id", "name", match.fk_tournament);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", match.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", match.fk_ticket);
            ViewBag.fk_first_team = new SelectList(db.teams, "id", "name", match.fk_first_team);
            ViewBag.fk_second_team = new SelectList(db.teams, "id", "name", match.fk_second_team);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            match match = db.matches.Find(id);
            db.matches.Remove(match);
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
