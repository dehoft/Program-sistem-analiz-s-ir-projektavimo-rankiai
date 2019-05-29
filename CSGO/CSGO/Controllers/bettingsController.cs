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
    public class BettingsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Bettings
        public ActionResult Index()
        {
            var bettings = db.bettings.Include(b => b.users_bets).Include(b => b.match);
            return View(bettings.ToList());
        }

        // GET: Bettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            betting betting = db.bettings.Find(id);
            if (betting == null)
            {
                return HttpNotFound();
            }
            return View(betting);
        }

        // GET: Bettings/Create
        public ActionResult Create()
        {
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id");
            ViewBag.fk_match = new SelectList(db.matches, "id", "map");
            return View();
        }

        // POST: Bettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coefficient,fk_users_bets,fk_match,team_name")] betting betting)
        {
            if (ModelState.IsValid)
            {
                db.bettings.Add(betting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", betting.fk_users_bets);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", betting.fk_match);
            return View(betting);
        }

        // GET: Bettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            betting betting = db.bettings.Find(id);
            if (betting == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", betting.fk_users_bets);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", betting.fk_match);
            return View(betting);
        }

        // POST: Bettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coefficient,fk_users_bets,fk_match")] betting betting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(betting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", betting.fk_users_bets);
            ViewBag.fk_match = new SelectList(db.matches, "id", "map", betting.fk_match);
            return View(betting);
        }

        // GET: Bettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            betting betting = db.bettings.Find(id);
            if (betting == null)
            {
                return HttpNotFound();
            }
            return View(betting);
        }

        // POST: Bettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            betting betting = db.bettings.Find(id);
            db.bettings.Remove(betting);
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
