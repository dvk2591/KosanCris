using KosanCrisTrips.Web.Models;
using KosanCrisTrips.Web.Models.Authentication;
using KosanCrisTrips.Web.Utilities;
using Newtonsoft.Json;
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
            ApiResponse response = new ApiResponse();

            //List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            //parameters = BuildApiParameters(loginUser);            

            ViewBag.DisplayOtpControl = false;
            if (ViewBag.AuthenticatedUser == null)
            {
                response = await WebApiClientUtility.Post<User>("users", loginUser, 0, "IsValidUser");
                if (response != null && response.Result != null)
                {
                    ViewBag.AuthenticatedUser = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                }
            }

            if (ViewBag.AuthenticatedUser != null && ViewBag.AuthenticatedUser.EmailId != null)
            {
                if (ViewBag.AuthenticatedUser.IsTemporaryPassword)
                {
                    return View("ForgotPassword", ViewBag.AuthenticatedUser);
                }

                ViewBag.DisplayOtpControl = true;
                return View(ViewBag.AuthenticatedUser);
            }
            else
            {
                return RedirectToAction("UnAuthorizedLogin");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ValidateOneTimePassword(User loginUser)
        {
            User authenticatedUser = new User();
            ApiResponse response = new ApiResponse();
            if (loginUser != null && loginUser.UserId != 0 && loginUser.OneTimePassword != null)
            {
                response = await WebApiClientUtility.Post<User>("users", loginUser, 0, "IsValidOTP");
                if (response != null && response.Result != null)
                {
                    authenticatedUser = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                }
            }
            if (authenticatedUser != null && authenticatedUser.UserRoles != null && authenticatedUser.UserRoles.Any())
            {
                TempData.Add("AuthenticatedUser", authenticatedUser);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("UnAuthorizedLogin");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ResendOTP(User loginUser)
        {
            User authenticatedUser = new User();
            ApiResponse response = new ApiResponse();
            if (loginUser != null && loginUser.UserId != 0)
            {
                response = await WebApiClientUtility.Post<User>("users", loginUser, 0, "ResendOtp");
                if (response != null && response.Result != null)
                {
                    authenticatedUser = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                }
            }

            if (authenticatedUser != null && authenticatedUser.EmailId != null)
            {

                ViewBag.DisplayOtpControl = true;
                return View("Index", authenticatedUser);
            }
            else
            {
                return RedirectToAction("UnAuthorizedLogin");
            }

        }

        public async Task<ActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(User userDetails)
        {
            ApiResponse response = new ApiResponse();
            User authenticatedUser = new User();
            if (userDetails != null && userDetails.EmailId != null && userDetails.PhoneNumber != null)
            {
                response = await WebApiClientUtility.Post<User>("users", userDetails, 0, "ForgotPassword");
                if (response != null && response.Result != null)
                {
                    authenticatedUser = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                }
            }

            if (authenticatedUser != null && authenticatedUser.UserId != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("UnAuthorizedLogin");
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(User userDetails)
        {
            return View(userDetails);
        }

        [HttpPost]
        public ActionResult SavePassword(User userDetails)
        {
            ApiResponse response = new ApiResponse();
            User authenticatedUser = new User();

            if (userDetails != null && userDetails.EmailId != null
                                    && userDetails.PhoneNumber != null
                                    && !string.IsNullOrEmpty(userDetails.Password)
                                    && !string.IsNullOrEmpty(userDetails.ConfirmPassword))

            {
                if (userDetails.Password.Equals(userDetails.ConfirmPassword))
                {
                    response = WebApiClientUtility.Post<User>("users", userDetails, 0, "SavePassword").Result;
                    if (response != null && response.Result != null)
                    {
                        authenticatedUser = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                    }

                    if (authenticatedUser != null && authenticatedUser.UserId != 0)
                    {
                        if (TempData != null && TempData.ContainsKey("AuthenticatedUser"))
                        {
                            TempData.Remove("AuthenticatedUser");
                        }
                        else
                        {
                            TempData.Add("AuthenticatedUser", authenticatedUser);
                        }

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("UnAuthorizedLogin");
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedLogin");
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedLogin");
            }
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
        private bool IsFirstTimeLogin(User loginUser)
        {
            ApiResponse response = new ApiResponse();
            bool IsFirstTimeLogin = false;

            if (Session != null && Session["IsFirstTimeLogin"] != null)
            {
                IsFirstTimeLogin = (bool)Session["IsFirstTimeLogin"];

                return IsFirstTimeLogin;
            }
            response = WebApiClientUtility.Post<User>("users", loginUser, 0, "IsFirstTimeLogin").Result;

            if (response != null && response.Result != null)
            {
                IsFirstTimeLogin = JsonConvert.DeserializeObject<bool>(response.Result.ToString());
                Session.Add("IsFirstTimeLogin", IsFirstTimeLogin);
            }

            return IsFirstTimeLogin;
        }
    }
}