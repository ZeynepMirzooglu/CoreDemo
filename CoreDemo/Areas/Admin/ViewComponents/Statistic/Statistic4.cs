using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.name=context.Admins.Where(x=>x.AdminId==1).Select(y=>y.Name).FirstOrDefault();
            ViewBag.imageUrl=context.Admins.Where(x=>x.AdminId==1).Select(y=>y.ImageUrl).FirstOrDefault();
            ViewBag.description = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
