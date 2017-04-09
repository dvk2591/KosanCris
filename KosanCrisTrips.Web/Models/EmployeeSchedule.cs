using System;

namespace KosanCrisTrips.Web.Models
{
    public class EmployeeSchedule
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}