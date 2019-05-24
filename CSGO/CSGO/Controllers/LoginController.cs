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
	public class LoginController : Controller
	{
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(user objUser)
		{
			if (ModelState.IsValid)
			{
				using (dbEntities db = new dbEntities())
				{
					var UserN = objUser.username;
					var UserP = objUser.password;
					var obj = db.users.Where(a => a.username.Equals(UserN) && a.password.Equals(UserP)).FirstOrDefault();
					if (obj != null)
					{
						Session["Id"] = obj.id;
						Session["userName"] = obj.username.ToString();
						Session["userLevel"] = obj.userLevel;
						Session["registeredGiveaway"] = obj.fk_giveaway;

						if (obj.userLevel == 1)
							return RedirectToAction("UserDashBoard");
						else
							return RedirectToAction("AdminDashBoard");

					}
				}
			}
			return View(objUser);
		}

		public ActionResult LogOut()
		{
			Session.Remove("Id");
			Session.Remove("userName");
			Session.Remove("userLevel");
			Session.Remove("registeredGiveaway");
			return RedirectToAction("Login","Login");
		}

		public ActionResult DashBoard()
		{
			if ((int)Session["userLevel"] == 1)
			{
				return RedirectToAction("UserDashBoard");
			}
			else
			{
				Session.Remove("GiveawayID");
				return RedirectToAction("AdminDashBoard");
			}
		}

		public ActionResult UserDashBoard()
		{
			if (Session["ID"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}
		}

		public ActionResult AdminDashBoard()
		{
			if (Session["ID"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}
		}
	}
}
