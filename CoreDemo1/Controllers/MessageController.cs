using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreDemo1.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        
        public IActionResult InBox()
        {
            int id = 2;
            var values = mm.GetInboxListWithByWriter(id);
            return View(values);
        }
       
        public IActionResult MesajDetails(int id)
        {
            var value = mm.TGetById(id);
            
            return View(value);
        }
    }
}
