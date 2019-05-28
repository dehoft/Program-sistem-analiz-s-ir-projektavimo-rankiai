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
    public class UsersBetsController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: UsersBets
        public ActionResult Index()
        {
            var users_bets = db.users_bets.Include(u => u.betting).Include(u => u.user);
            return View(users_bets.ToList());
        }

        // GET: UsersBets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bets users_bets = db.users_bets.Find(id);
            if (users_bets == null)
            {
                return HttpNotFound();
            }
            return View(users_bets);
        }

        // GET: UsersBets/Create
        public ActionResult Create()
        {
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id");
            ViewBag.fk_user = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: UsersBets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bet_value,won,fk_user,fk_betting")] users_bets users_bets)
        {
            if (ModelState.IsValid)
            {
				users_bets.fk_user = (int)Session["Id"];
				users_bets.fk_betting = (int)Session["BetId"];
				Session.Remove("BetId");
				db.users_bets.Add(users_bets);
                db.SaveChanges();
                return RedirectToAction("Index","Tournaments");
            }

            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bets.fk_betting);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bets.fk_user);
            return View(users_bets);
        }

        // GET: UsersBets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bets users_bets = db.users_bets.Find(id);
            if (users_bets == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bets.fk_betting);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bets.fk_user);
            return View(users_bets);
        }

        // POST: UsersBets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bet_value,won,fk_user,fk_betting")] users_bets users_bets)
        {
            if (ModelState.IsValid)
            {
				users_bets.fk_user = (int)Session["Id"];
				users_bets.fk_betting = (int)Session["BetId"];
				Session.Remove("BetId");
				db.Entry(users_bets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_betting = new SelectList(db.bettings, "id", "id", users_bets.fk_betting);
            ViewBag.fk_user = new SelectList(db.users, "id", "username", users_bets.fk_user);
            return View(users_bets);
        }

        // GET: UsersBets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_bets users_bets = db.users_bets.Find(id);
            if (users_bets == null)
            {
                return HttpNotFound();
            }
            return View(users_bets);
        }

        // POST: UsersBets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users_bets users_bets = db.users_bets.Find(id);
            db.users_bets.Remove(users_bets);
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
