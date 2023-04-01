using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class LoginController: Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel user)
		{
			if (ModelState.IsValid)
			{
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
                if (result.Succeeded)
                {
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					return RedirectToAction("Index", "Login");

				}
            }

            return View();
        }
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Login");
		}
		public IActionResult AccessDenied()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult>  Index(Writer writer)
        //{
        //	Context context = new Context();
        //	var dataValue = context.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);
        //	if(dataValue != null)
        //	{
        //		var claims = new List<Claim> { new Claim(ClaimTypes.Name, writer.WriterEmail) };
        //		var userIdentity=new ClaimsIdentity(claims,"a");
        //		ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(userIdentity);
        //		await HttpContext.SignInAsync(claimsPrincipal);
        //		return RedirectToAction("Index","Dashboard");
        //	}
        //	else
        //	{
        //		return View();
        //	}
        //}
    }
}

