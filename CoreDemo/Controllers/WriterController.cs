using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class WriterController: Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
         Context _context=new Context();
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail=userMail;
            Context context = new Context();
            var writerName=context.Writers.Where(x=>x.WriterEmail==userMail).Select(y=>y.WriterFullName).FirstOrDefault();
            ViewBag.writerName=writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
      
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
      
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var writerValues = writerManager.TGetById(writerId);
            return View(writerValues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult results = validations.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage image)
        {
            Writer writer = new Writer();
            if (image.WriterImage != null)
            {
                var extension = Path.GetExtension(image
                    .WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                image
                    .WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterEmail = image.WriterEmail;
            writer.WriterPassword = image.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = image.WriterAbout;
            writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");

        }
    }
}
