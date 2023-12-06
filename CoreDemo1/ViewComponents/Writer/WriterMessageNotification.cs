using BlogApiDemo.DataAccessLayer;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo1.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm=new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            DataAccessLayer.Concrete.Context context = new DataAccessLayer.Concrete.Context();
            var userName=User.Identity.Name;
            var userId=context.Users.Where(x=> x.UserName == userName).Select(y=>y.Id).FirstOrDefault();
            var values = mm.GetInboxListWithByUser(userId);
            return View(values);
        }
    }
}
