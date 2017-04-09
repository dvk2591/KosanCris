using KosanCrisTrips.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Models
{
    public class Schedule
    {
        public string UniqueCode { get; set; }
        public string Location { get; set; }
        public NatureOfService SelectedNatureOfService { get; set; }
        public Company SelectedCompany { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<EmployeeSchedule> EmployeesSchedule { get; set; }
    }
}