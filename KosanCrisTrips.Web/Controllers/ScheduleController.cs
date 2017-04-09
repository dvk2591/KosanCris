using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return RedirectToAction("CreateSchedule");
        }

        public ActionResult CreateSchedule()
        {
            return View();
        }
    }
}