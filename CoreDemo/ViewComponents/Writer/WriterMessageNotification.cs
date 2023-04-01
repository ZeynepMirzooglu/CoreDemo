using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageWriterManager messageWriterManager = new MessageWriterManager(new EfMessageWriterRepository());
        Context _context;

        public WriterMessageNotification(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = messageWriterManager.GetInBoxByWriter(writerId);
            return View(values);
        }

    }
}
