
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo1.Controllers
{
    
    public class MessageController : Controller
    {
        
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        UserManager um=new UserManager(new EfUserRepository());
        Context c = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxListWithByUser(userId);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetSendboxListWithByUser(userId);
            return View(values);
        }
       
        public IActionResult MesajDetails(int id)
        {
            var value = mm.TGetById(id);
            
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
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
        public IActionResult SendMessage(Message2 message2) 
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            
            message2.SenderID = userId;
            
            message2.MessageStatus = true;
            message2.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(message2);
            return RedirectToAction("Inbox");
        }
    }
}
