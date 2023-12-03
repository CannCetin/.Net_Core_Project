using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo1.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
			
			p.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
            cm.CommentAdd(p);
            return RedirectToAction("Index","Blog");
        }
        public PartialViewResult CommentListByBlog(int id) 
		{
			var values =cm.GetList(id);
			return PartialView(values);
		} 
	}
}
