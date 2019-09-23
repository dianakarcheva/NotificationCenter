using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NotificationCenter.Web.Models;
using NotificationCenter.Interfaces;
using NotificationCenter.Web.Helpers;

namespace NotificationCenter.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;

        public AccountController(IAuthenticationService authenticationService, ICustomerService customerService)
        {
            this._authenticationService = authenticationService;
            this._customerService = customerService;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return SessionHelper.IsAuthenticated 
                ? RedirectToAction("Index", "Home") 
                : RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (SessionHelper.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResult = await _authenticationService.LoginAsync(model.Username, model.Password);

            if (loginResult.Success)
            {
                var notifications = _customerService.GetClientNotificationsAsync(loginResult.User.Id);

                SessionHelper.CurrentUser = loginResult.User;

                SessionHelper.ClientNotifications = (await notifications).ToList();

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            SessionHelper.CloseSession();
            return RedirectToAction("Login");
        }
    }
}