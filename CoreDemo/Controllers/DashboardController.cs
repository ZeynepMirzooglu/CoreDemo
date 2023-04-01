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
            var userName = User.Identity.Name;
            var userEmail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId =context.Writers.Where(x => x.WriterEmail==userEmail).Select(x => x.WriterId).FirstOrDefault();

            ViewBag.blogCount = context.Blogs.Count().ToString();
            ViewBag.blogCountMy = context.Blogs.Where(x => x.WriterId == writerId).Count().ToString();
            ViewBag.totalBlogCount=context.Categories.Count().ToString();
            return View();
        }
    }
}
