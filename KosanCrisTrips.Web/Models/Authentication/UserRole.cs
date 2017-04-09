using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosanCrisTrips.Web.Models.Authentication
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}