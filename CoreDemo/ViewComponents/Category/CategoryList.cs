﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = categoryManager.GetAllList();
			return View(values);
		}

	}
}
