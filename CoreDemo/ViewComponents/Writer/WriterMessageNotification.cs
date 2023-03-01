using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageWriterManager messageWriterManager = new MessageWriterManager(new EfMessageWriterRepository());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = messageWriterManager.GetInBoxByWriter(id);
            return View(values);
        }

    }
}
