using KosanCrisTrips.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Controllers
{
    public class LookUpController : Controller
    {
        List<LookUpViewModel> _customerLocationsLookUp;
        List<LookUpViewModel> _natureOfServices;

        // GET: LookUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCustomerLocations(string searchText)
        {
            _customerLocationsLookUp = new List<LookUpViewModel>();

            if (TempData.ContainsKey("CustomerLocationsLookUp"))
            {
                _customerLocationsLookUp = TempData["CustomerLocationsLookUp"] as List<LookUpViewModel>;                
            }

            return Json(_customerLocationsLookUp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetNatureOfServices(string searchText)
        {
            _natureOfServices = new List<LookUpViewModel>();
            if (TempData.ContainsKey("NatureOfServices"))
            {
                _natureOfServices = TempData["NatureOfServices"] as List<LookUpViewModel>;
            }

            return Json(_natureOfServices, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetWorkOrders(string selectedLocation, string selectedNatureOfService)
        {
            //TODO: Call api to get work orders and add to temp data.
            return RedirectToAction("CreateSchedule", "Schedule");
        }
    }
}