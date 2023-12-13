using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;

namespace CoreDemo1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager=new CommentManager(new EfCommentRepository());
        Context context=new Context();
        public IActionResult Index()
        {
            var values=commentManager.GetCommentWithBlog();
            return View(values);
        }
        
    }
    
}
