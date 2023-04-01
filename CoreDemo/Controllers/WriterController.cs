using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController: Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Context _context = new Context();
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterFullName).FirstOrDefault();
            ViewBag.writerName = writerName;
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
        public async Task<IActionResult> WriterEditProfile()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.FullName = userName.FullName;
            userUpdateViewModel.Email = userName.Email;
            userUpdateViewModel.ImageUrl = userName.ImageUrl;
            userUpdateViewModel.UserName= userName.UserName;
            return View(userUpdateViewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.UserName = userUpdateViewModel.UserName;
            values.FullName= userUpdateViewModel.FullName;
            values.Email= userUpdateViewModel.Email;
            values.ImageUrl= userUpdateViewModel.ImageUrl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,userUpdateViewModel.Password);
            var result= await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
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
