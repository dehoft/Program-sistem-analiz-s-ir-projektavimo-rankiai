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
    public class UsersBetSkinsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: UsersBetSkins
        public ActionResult Index()
        {
            var users_bet_skins = db.users_bet_skins.Include(u => u.betting).Include(u => u.skin).Include(u => u.user);
            return View(users_bet_skins.ToList());
        }

        // GET: UsersBetSkins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bet_skins users_bet_skins = db.users_bet_skins.Find(id);
            if (users_bet_skins == null)
            {
                return HttpNotFound();
            }
            return View(users_bet_skins);
        }

        // GET: UsersBetSkins/Create
        public ActionResult Create()
        {
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id");
            ViewBag.fk_skin = new SelectList(db.skins, "id", "name");
            ViewBag.fk_user = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: UsersBetSkins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,won,fk_user,fk_betting,fk_skin")] users_bet_skins users_bet_skins)
        {
            if (ModelState.IsValid)
            {
				users_bet_skins.fk_user = (int)Session["Id"];
				users_bet_skins.fk_betting = (int)Session["BetId"];
				Session.Remove("BetId");
				db.users_bet_skins.Add(users_bet_skins);
                db.SaveChanges();
                return RedirectToAction("Index","Tournaments");
            }

            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bet_skins.fk_betting);
            ViewBag.fk_skin = new SelectList(db.skins, "id", "name", users_bet_skins.fk_skin);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bet_skins.fk_user);
            return View(users_bet_skins);
        }

        // GET: UsersBetSkins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bet_skins users_bet_skins = db.users_bet_skins.Find(id);
            if (users_bet_skins == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bet_skins.fk_betting);
            ViewBag.fk_skin = new SelectList(db.skins, "id", "name", users_bet_skins.fk_skin);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bet_skins.fk_user);
            return View(users_bet_skins);
        }

        // POST: UsersBetSkins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,won,fk_user,fk_betting,fk_skin")] users_bet_skins users_bet_skins)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users_bet_skins).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bet_skins.fk_betting);
            ViewBag.fk_skin = new SelectList(db.skins, "id", "name", users_bet_skins.fk_skin);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bet_skins.fk_user);
            return View(users_bet_skins);
        }

        // GET: UsersBetSkins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bet_skins users_bet_skins = db.users_bet_skins.Find(id);
            if (users_bet_skins == null)
            {
                return HttpNotFound();
            }
            return View(users_bet_skins);
        }

        // POST: UsersBetSkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users_bet_skins users_bet_skins = db.users_bet_skins.Find(id);
            db.users_bet_skins.Remove(users_bet_skins);
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
