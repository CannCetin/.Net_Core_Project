using CoreDemo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace CoreDemo1.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					UserName = "Alican"
				},
				new UserComment
				{
					ID=2,
					UserName="Mesut"
				},
				new UserComment
				{
					ID=3,
					UserName="Merve"
				}
			};
			return View(commentvalues);
		}
	}
}
