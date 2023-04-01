using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context context = new Context();
        
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.userName= userName;
            var userEmail=context.Users.Where(x=>x.UserName==userName).Select(x=>x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterEmail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
