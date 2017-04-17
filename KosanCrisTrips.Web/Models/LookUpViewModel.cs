using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosanCrisTrips.Web.Models
{
    public class LookUpViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int NatureOfServiceId { get; set; }

    }
}