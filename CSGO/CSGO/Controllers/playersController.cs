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
    public class playersController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: players
        public ActionResult Index()
        {
            var players = db.players.Include(p => p.person).Include(p => p.team).Include(p => p.rating1);
            return View(players.ToList());
        }

        // GET: players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: players/Create
        public ActionResult Create()
        {
            ViewBag.fk_person = new SelectList(db.persons, "id", "username");
            ViewBag.fk_team = new SelectList(db.teams, "id", "name");
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id");
            return View();
        }

        // POST: players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,rating,age,country,assists,headshots,damage_per_second,fk_person,fk_rating,fk_team")] player player)
        {
            if (ModelState.IsValid)
            {
                db.players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_person = new SelectList(db.persons, "id", "username", player.fk_person);
            ViewBag.fk_team = new SelectList(db.teams, "id", "name", player.fk_team);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", player.fk_rating);
            return View(player);
        }

        // GET: players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_person = new SelectList(db.persons, "id", "username", player.fk_person);
            ViewBag.fk_team = new SelectList(db.teams, "id", "name", player.fk_team);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", player.fk_rating);
            return View(player);
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,rating,age,country,assists,headshots,damage_per_second,fk_person,fk_rating,fk_team")] player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_person = new SelectList(db.persons, "id", "username", player.fk_person);
            ViewBag.fk_team = new SelectList(db.teams, "id", "name", player.fk_team);
            ViewBag.fk_rating = new SelectList(db.ratings, "id", "id", player.fk_rating);
            return View(player);
        }

        // GET: players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            player player = db.players.Find(id);
            db.players.Remove(player);
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
