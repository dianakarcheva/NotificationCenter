using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NotificationCenter.Interfaces;
using NotificationCenter.Web.Models;
using NotificationCenter.Web.Helpers;

namespace NotificationCenter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public ActionResult Index()
        {
            var homeViewModel = new HomeModel()
            {
                User = SessionHelper.CurrentUser.Username,
                Notifications = SessionHelper.ClientNotifications
            };

            return View(homeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult MarkAsSeen(long notificationId)
        {
            _customerService.MarkNotificationAsSeen(notificationId);
            
            return Json(new {
                Id = notificationId,
                Result = "OK"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(long notificationId)
        {
            _customerService.DeleteNotification(notificationId);

            return Json(new
            {
                Id = notificationId,
                Result = "OK"
            });
        }
    }
}