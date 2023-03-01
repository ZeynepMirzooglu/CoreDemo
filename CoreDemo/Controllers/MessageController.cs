using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController: Controller
    {
        MessageWriterManager messageWriterManager = new MessageWriterManager(new EfMessageWriterRepository());
        public IActionResult InBox()
        {
            int id = 1;
            var values=messageWriterManager.GetInBoxByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value=messageWriterManager.TGetById(id);
            return View(value);
        }
    }
}
