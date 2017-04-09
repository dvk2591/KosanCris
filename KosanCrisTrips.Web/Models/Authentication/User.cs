using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosanCrisTrips.Web.Models.Authentication
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string OneTimePassword { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}