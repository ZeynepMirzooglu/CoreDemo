using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController: Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.blogCount = context.Blogs.Count().ToString();
            ViewBag.blogCountMy = context.Blogs.Where(x => x.WriterId == 1).Count().ToString();
            ViewBag.totalBlogCount=context.Categories.Count().ToString();
            return View();
        }
    }
}
