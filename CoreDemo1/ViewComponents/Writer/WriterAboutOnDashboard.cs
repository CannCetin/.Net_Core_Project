using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo1.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());
        
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
           
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var userID = c.Users.Where(x => x.UserName==username).Select(y=>y.Id).FirstOrDefault();
            var values = new List<AppUser> { um.TGetById(userID) };
            return View(values);
        }
    }
}
