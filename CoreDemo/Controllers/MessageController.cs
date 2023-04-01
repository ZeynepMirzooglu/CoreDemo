using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Controllers
{
   
    public class MessageController: Controller
    {
        MessageWriterManager messageWriterManager = new MessageWriterManager(new EfMessageWriterRepository());
        Context _context;

        public MessageController(Context context)
        {
            _context = context;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail=_context.Users.Where(x=>x.UserName==userName).Select(y=>y.Email).FirstOrDefault();
            var writerId=_context.Writers.Where(x=>x.WriterEmail==userMail).Select(y=>y.WriterId).FirstOrDefault();
            var values=messageWriterManager.GetInBoxByWriter(writerId);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value=messageWriterManager.TGetById(id);
            return View(value);
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
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(MessageWriter messageWriter)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            messageWriter.SenderId=writerId;
            messageWriter.ReceiverId = 5;
            messageWriter.MessageStatus = true;
            messageWriter.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            messageWriterManager.Add(messageWriter);

            return RedirectToAction("InBox");
        }
    }
}
