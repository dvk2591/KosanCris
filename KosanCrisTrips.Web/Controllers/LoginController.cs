using KosanCrisTrips.Web.Models.Authentication;
using KosanCrisTrips.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.DisplayOtpControl = false;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(User loginUser)
        {
            User authenticatedUser = new User();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters = BuildApiParameters(loginUser);
            ViewBag.DisplayOtpControl = false;
            //if (ViewBag.AuthenticatedUser == null)
            //{
            //    authenticatedUser = await WebApiClientUtility.Get<User>(parameters);
            //    ViewBag.AuthenticatedUser = authenticatedUser;
            //}

            //if (ViewBag.AuthenticatedUser != null)
            //{
                ViewBag.DisplayOtpControl = true;
                return View();
            //}
            //else
            //{
            //    return RedirectToAction("UnAuthorizedLogin");
            //}
        }

        public ActionResult OneTimePassword()
        {
            return View("OneTimePassword");
        }


        private List<KeyValuePair<string, string>> BuildApiParameters(User loginUser)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>(nameof(loginUser.EmailId), loginUser.EmailId));
            parameters.Add(new KeyValuePair<string, string>(nameof(loginUser.Password), loginUser.Password));

            return parameters;
        }
    }
}