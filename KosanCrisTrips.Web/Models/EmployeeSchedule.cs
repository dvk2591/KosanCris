using System;

namespace KosanCrisTrips.Web.Models
{
    public class EmployeeSchedule
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}