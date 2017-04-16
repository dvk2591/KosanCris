using KosanCrisTrips.Web.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            User authenticatedUser = new User();

            if (TempData != null && TempData.Any(x => x.Key == "AuthenticatedUser"))
            {
                authenticatedUser = TempData["AuthenticatedUser"] as User;
                ViewBag.UserName = authenticatedUser.UserName;
            }
            return View(authenticatedUser);
        }
    }
}