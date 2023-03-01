using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController: Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var result = aboutManager.GetAllList();
            return View(result);
		}
		public PartialViewResult SocialMediaAbout()
		{
			var result = aboutManager.GetAllList();
			return PartialView();
		}
	}
}
