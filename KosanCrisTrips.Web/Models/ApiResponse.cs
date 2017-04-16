using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KosanCrisTrips.Web.Models
{
    public class ApiResponse
    {
        public List<Error> Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
    }
}