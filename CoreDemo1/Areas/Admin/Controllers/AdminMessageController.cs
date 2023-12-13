using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
	{
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        UserManager um = new UserManager(new EfUserRepository());
        Context c = new Context();

        public IActionResult Inbox()
		{
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var messageCount = c.Message2s.Where(x => x.ReceiverID == userId).Count();
            ViewBag.MessageCount = messageCount;
            var values = mm.GetInboxListWithByUser(userId);
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var messageCount=c.Message2s.Where(x=>x.SenderID== userId).Count();
            ViewBag.MessageCount1 = messageCount;
            var values = mm.GetSendboxListWithByUser(userId);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            List<SelectListItem> uservalues = (from x in um.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = $"{x.NameSurname} - {x.Email}",
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.cv = uservalues;
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 message2)
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            message2.SenderID = userId;
            message2.MessageDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.MessageStatus = true;
            mm.TAdd(message2);
            return RedirectToAction("Sendbox","AdminMessage");
        }
        [HttpPost]
        public IActionResult DeleteMessage(Message2 message2)
        {
            
            mm.TDelete(message2);
            return RedirectToAction("Inbox");
        }
    }
}
