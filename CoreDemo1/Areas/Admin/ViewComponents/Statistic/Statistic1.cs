using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo1.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3=c.Comments.Count();
            
            string connection = "http://api.weatherapi.com/v1/current.xml?key=a174cad82aba453ba98192311232311%20&q=40.14556,%2026.40639&aqi=no";
            XDocument document=XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temp_c").ElementAt(0).Value;
            return View();
        }
    }
}
