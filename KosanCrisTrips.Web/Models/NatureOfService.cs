using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosanCrisTrips.Web.Models
{
    public class NatureOfService
    {
        public string ServiceCategory { get; set; }
        public bool IsReportRequired { get; set; }
        public bool CanCloseSchedule { get; set; }
    }
}