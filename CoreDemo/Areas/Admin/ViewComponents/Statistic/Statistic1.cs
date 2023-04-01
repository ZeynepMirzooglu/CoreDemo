using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.value = _blogManager.GetAllList().Count;
            ViewBag.contact = _context.Contacts.Count();
            ViewBag.comment=_context.Comments.Count();
            string api = "501fc2659989a5e929b4feddc299164e";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document= XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature")
                .ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
