using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeStyle;

namespace CoreDemo1.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm= new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values=nm.GetList();
            return View(values);

        }
    }
}
