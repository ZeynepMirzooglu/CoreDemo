﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController: Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
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
		public IActionResult PartialAddComment(Comment comment)
		{
			comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogId = 1;
			commentManager.Add(comment);
			return View();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values=commentManager.GetList(id);
			return PartialView(values);
		}
	}
}
