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
    public class UsersController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.evaluation).Include(u => u.giveaway).Include(u => u.place).Include(u => u.ticket).Include(u => u.users_bets1);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
			if (Session["Id"] != null)
				id = (int)Session["Id"];

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description");
            ViewBag.fk_giveaway = new SelectList(db.giveaways, "id", "description");
            ViewBag.fk_place = new SelectList(db.places, "id", "id");
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description");
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,userLevel,first_name,last_name,sex,email,fk_ticket,fk_users_bets,fk_giveaway,fk_evaluation,fk_place")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", user.fk_evaluation);
            ViewBag.fk_giveaway = new SelectList(db.giveaways, "id", "description", user.fk_giveaway);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", user.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", user.fk_ticket);
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", user.fk_users_bets);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", user.fk_evaluation);
            ViewBag.fk_giveaway = new SelectList(db.giveaways, "id", "description", user.fk_giveaway);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", user.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", user.fk_ticket);
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", user.fk_users_bets);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,userLevel,first_name,last_name,sex,email,fk_ticket,fk_users_bets,fk_giveaway,fk_evaluation,fk_place")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_evaluation = new SelectList(db.evaluations, "id", "description", user.fk_evaluation);
            ViewBag.fk_giveaway = new SelectList(db.giveaways, "id", "description", user.fk_giveaway);
            ViewBag.fk_place = new SelectList(db.places, "id", "id", user.fk_place);
            ViewBag.fk_ticket = new SelectList(db.tickets, "id", "description", user.fk_ticket);
            ViewBag.fk_users_bets = new SelectList(db.users_bets, "id", "id", user.fk_users_bets);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		// GET: Users/Referral/5
		public ActionResult Referral(string id)
		{
			if (Session["Id"] != null)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				referral referral = db.referrals.Find(id);
				if (referral == null)
				{
					return HttpNotFound();
				}
				users_in_giveaway users_in_giveaway = new users_in_giveaway();
				users_in_giveaway.fk_giveaway = referral.fk_giveaway;
				users_in_giveaway.fk_user = (int)Session["Id"];
				var usersGiveaway = db.users_in_giveaway.ToList();
				var boo = true;
				foreach(var item in usersGiveaway)
				{
					if (item.fk_giveaway == referral.fk_giveaway && item.fk_user == (int)Session["Id"])
						boo = false;
				}
				if (boo)
				{
					db.users_in_giveaway.Add(users_in_giveaway);
					db.SaveChanges();
					referral.count++;
					db.Entry(referral).State = EntityState.Modified;
					db.SaveChanges();
				}
				return RedirectToAction("Details", "Giveaways", new { id = referral.fk_giveaway });
			}else
			{
				return RedirectToAction("Login","Login");
			}
		}
		public ActionResult Bet(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return RedirectToAction("Create", "UsersBets");
		}
		public ActionResult MoneyDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return RedirectToAction("Delete", "UsersBets", new { id = id });
		}
		public ActionResult SkinDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return RedirectToAction("Delete", "UsersBetSkins", new { id = id });
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
