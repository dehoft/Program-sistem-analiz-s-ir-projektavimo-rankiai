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
    public class giveawaysController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: giveaways
        public ActionResult Index()
        {
            var giveaways = db.giveaways.Include(g => g.skins_in_giveaway).Include(g => g.users_in_giveaway);
            return View(giveaways.ToList());
        }

        // GET: giveaways/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giveaway giveaway = db.giveaways.Find(id);
            if (giveaway == null)
            {
                return HttpNotFound();
            }
            return View(giveaway);
        }

        // GET: giveaways/Create
        public ActionResult Create()
        {
            ViewBag.fk_skinsInGiveaway = new SelectList(db.skins_in_giveaway, "id", "id");
            ViewBag.fk_usersInGiveaway = new SelectList(db.users_in_giveaway, "id", "id");
            return View();
        }

        // POST: giveaways/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,start_time,end_time,fk_skinsInGiveaway,fk_usersInGiveaway")] giveaway giveaway)
        {
            if (ModelState.IsValid)
            {
                db.giveaways.Add(giveaway);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_skinsInGiveaway = new SelectList(db.skins_in_giveaway, "id", "id", giveaway.fk_skinsInGiveaway);
            ViewBag.fk_usersInGiveaway = new SelectList(db.users_in_giveaway, "id", "id", giveaway.fk_usersInGiveaway);
            return View(giveaway);
        }

        // GET: giveaways/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giveaway giveaway = db.giveaways.Find(id);
            if (giveaway == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_skinsInGiveaway = new SelectList(db.skins_in_giveaway, "id", "id", giveaway.fk_skinsInGiveaway);
            ViewBag.fk_usersInGiveaway = new SelectList(db.users_in_giveaway, "id", "id", giveaway.fk_usersInGiveaway);
            return View(giveaway);
        }

        // POST: giveaways/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,start_time,end_time,fk_skinsInGiveaway,fk_usersInGiveaway")] giveaway giveaway)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giveaway).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_skinsInGiveaway = new SelectList(db.skins_in_giveaway, "id", "id", giveaway.fk_skinsInGiveaway);
            ViewBag.fk_usersInGiveaway = new SelectList(db.users_in_giveaway, "id", "id", giveaway.fk_usersInGiveaway);
            return View(giveaway);
        }

        // GET: giveaways/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giveaway giveaway = db.giveaways.Find(id);
            if (giveaway == null)
            {
                return HttpNotFound();
            }
            return View(giveaway);
        }

        // POST: giveaways/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            giveaway giveaway = db.giveaways.Find(id);
            db.giveaways.Remove(giveaway);
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
