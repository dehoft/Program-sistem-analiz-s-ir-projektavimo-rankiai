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
    public class GiveawaysController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Giveaways
        public ActionResult Index()
        {
            var giveaways = db.giveaways.Include(g => g.skins_in_giveaway).Include(g => g.users_in_giveaway);
			Session.Remove("GiveawayID");
            return View(giveaways.ToList());
        }

        // GET: Giveaways/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giveaway giveaway = db.giveaways.Find(id);
			//var skin = db.skins;

			if (giveaway == null)
            {
                return HttpNotFound();
            }
            return View(giveaway);
        }

        // GET: Giveaways/Create
        public ActionResult Create()
        {
            ViewBag.fk_skinsInGiveaway = new SelectList(db.skins_in_giveaway, "id", "id");
            ViewBag.fk_usersInGiveaway = new SelectList(db.users_in_giveaway, "id", "id");
            return View();
        }

        // POST: Giveaways/Create
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

        // GET: Giveaways/Edit/5
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

        // POST: Giveaways/Edit/5
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

        // GET: Giveaways/Delete/5
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

        // POST: Giveaways/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            giveaway giveaway = db.giveaways.Find(id);
            db.giveaways.Remove(giveaway);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		// GET: Giveaways/Add/5
		public ActionResult Add(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Session["GiveawayID"] = id;
			return RedirectToAction("Index", "Skins");
		}

		// GET: Giveaways/Remove/5
		public ActionResult Remove(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Session["RemoveSkinId"] = id;
			return RedirectToAction("Remove", "Skins");
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
