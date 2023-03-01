using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents
{
	public class CommentList: ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			var commentValues = new List<UserComment> 
			{
				new UserComment
				{
					Id = 1,
					UserName= "Zeynep",
			    },
				new UserComment
				{
					Id = 2,
					UserName="Gani"
				},
				new UserComment
				{
					Id = 3,
					UserName="Muhammed"
				}
			
			};
			return View(commentValues);
		}

	}
}
