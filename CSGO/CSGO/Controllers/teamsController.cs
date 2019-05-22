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
    public class teamsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: teams
        public ActionResult Index()
        {
            var teams = db.teams.Include(t => t.match).Include(t => t.player).Include(t => t.rating);
            return View(teams.ToList());
        }

        // GET: teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team team = db.teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: teams/Create
        public ActionResult Create()
        {
            ViewBag.fk_match = new SelectList(db.matches, "id", "map");
            ViewBag.fk_player = new SelectList(db.players, "id", "username");
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id");
            return View();
        }

        // POST: teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,wins,defeats,fk_match,fk_player,fk_rating")] team team)
        {
            if (ModelState.IsValid)
            {
                db.teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_match = new SelectList(db.matches, "id", "map", team.fk_match);
            ViewBag.fk_player = new SelectList(db.players, "id", "username", team.fk_player);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", team.fk_rating);
            return View(team);
        }

        // GET: teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team team = db.teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", team.fk_match);
            ViewBag.fk_player = new SelectList(db.players, "id", "username", team.fk_player);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", team.fk_rating);
            return View(team);
        }

        // POST: teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,wins,defeats,fk_match,fk_player,fk_rating")] team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", team.fk_match);
            ViewBag.fk_player = new SelectList(db.players, "id", "username", team.fk_player);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", team.fk_rating);
            return View(team);
        }

        // GET: teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team team = db.teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            team team = db.teams.Find(id);
            db.teams.Remove(team);
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
