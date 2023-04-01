using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController: Controller
    {
        MessageWriterManager messageWriterManager = new MessageWriterManager(new EfMessageWriterRepository());
        Context _context;

        public AdminMessageController(Context context)
        {
            _context = context;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = messageWriterManager.GetInBoxByWriter(writerId);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = messageWriterManager.GetSendBoxByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(MessageWriter messageWriter)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var receiverId = _context.MessageWriters.Select(x => x.ReceiverId).FirstOrDefault();
            messageWriter.SenderId = writerId;
            messageWriter.ReceiverId = receiverId;
            messageWriter.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            messageWriter.MessageStatus = true;
            messageWriterManager.Add(messageWriter);
            return RedirectToAction("SendBox");
        }
    }
}
