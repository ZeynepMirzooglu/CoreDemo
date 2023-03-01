using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController: Controller
    {
        NewsLetterManager manager=new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeEmail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeEmail(NewsLetter newsLetter)
        {
            newsLetter.EmailStatus = true;
            manager.AddNewsLetter(newsLetter);
            return PartialView();
        }
    }
}
