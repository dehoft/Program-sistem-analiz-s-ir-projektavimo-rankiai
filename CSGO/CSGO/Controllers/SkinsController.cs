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
    public class SkinsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Skins
        public ActionResult Index()
        {
            return View(db.skins.ToList());
        }

        // GET: Skins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }

        // GET: Skins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,fk_skinsInGiveaway")] skin skin)
        {
            if (ModelState.IsValid)
            {
                db.skins.Add(skin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skin);
        }

        // GET: Skins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }

        // POST: Skins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,fk_skinsInGiveaway")] skin skin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skin);
        }

        // GET: Skins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }

        // POST: Skins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skin skin = db.skins.Find(id);
            db.skins.Remove(skin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		// GET: Skins/Add/5
		public ActionResult Add(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			skin skin = db.skins.Find(id);
			if (skin == null)
			{
				return HttpNotFound();
			}
			return View(skin);
		}

		// POST: Skins/Add/5
		[HttpPost, ActionName("Add")]
		[ValidateAntiForgeryToken]
		public ActionResult AddConfirmed(int id)
		{
			skin skin = db.skins.Find(id);
			giveaway giveaway = db.giveaways.Find(Session["GiveawayID"]);
			skins_in_giveaway skins_in_giveaway = new skins_in_giveaway();
			skins_in_giveaway.fk_giveaway = giveaway.id;
			skins_in_giveaway.fk_skin = skin.id;
			db.skins_in_giveaway.Add(skins_in_giveaway);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Remove(int? id)
		{
			skins_in_giveaway skins_in_giveaway = db.skins_in_giveaway.Find(id);

			if (skins_in_giveaway == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			db.skins_in_giveaway.Remove(skins_in_giveaway);
			db.SaveChanges();
			return RedirectToAction("Index", "Giveaways");
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
