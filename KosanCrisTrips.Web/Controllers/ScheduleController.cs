using KosanCrisTrips.Web.Models;
using KosanCrisTrips.Web.Models.Authentication;
using KosanCrisTrips.Web.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Controllers
{
    public class ScheduleController : Controller
    {
        List<LookUpViewModel> _customerLocationsLookUp;
        List<LookUpViewModel> _natureOfServices;
        public ScheduleController()
        {            
            
            

        }
        // GET: Schedule
        public ActionResult Index()
        {
            Session.Add("UserId", 1);
            LoadLookups();
            return RedirectToAction("CreateSchedule");
        }

        private void LoadLookups()
        {
            ApiResponse response = new ApiResponse();
            response = WebApiClientUtility.Post<LookUpViewModel>("Lookup", null, Session["UserId"], "CustomerLocations").Result;
            if (response != null && response.Result != null)
            {
                _customerLocationsLookUp = JsonConvert.DeserializeObject<List<LookUpViewModel>>(response.Result.ToString());
                if (!TempData.ContainsKey("CustomerLocationsLookUp"))
                {
                    TempData.Add("CustomerLocationsLookUp", _customerLocationsLookUp);
                }
               
            }

            response = WebApiClientUtility.Post<LookUpViewModel>("Lookup", null, Session["UserId"], "NatureOfServices").Result;
            if (response != null && response.Result != null)
            {
                _natureOfServices = JsonConvert.DeserializeObject<List<LookUpViewModel>>(response.Result.ToString());
                if (!TempData.ContainsKey("NatureOfServices"))
                {
                    //LookUpViewModel vm = new LookUpViewModel() { Id=1,Name="AMC"};
                    //_natureOfServices.Add(vm);
                    TempData.Add("NatureOfServices", _natureOfServices);
                }
            }
        }

        public ActionResult CreateSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.EmployeesSchedule = new List<EmployeeSchedule>();
                      

            for (int i = 1; i <= 10; i++)
            {
                EmployeeSchedule empSchedule = new EmployeeSchedule()
                { EmployeeName = "Kosan Name" + i, StartDate = DateTime.Now.AddDays(i).ToShortDateString(), EndDate = DateTime.Now.AddDays(10 + i).ToShortDateString() };

                schedule.EmployeesSchedule.Add(empSchedule);
            }

            return View(schedule);
        }
    }
}