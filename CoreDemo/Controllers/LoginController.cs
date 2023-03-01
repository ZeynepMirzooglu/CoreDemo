using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult>  Index(Writer writer)
		{
			Context context = new Context();
			var dataValue = context.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);
			if(dataValue != null)
			{
				var claims = new List<Claim> { new Claim(ClaimTypes.Name, writer.WriterEmail) };
				var userIdentity=new ClaimsIdentity(claims,"a");
				ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(claimsPrincipal);
				return RedirectToAction("Index","Dashboard");
			}
			else
			{
				return View();
			}
		}
	}
}
//Context context = new Context();
//var dataValue = context.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);
//if (dataValue != null)
//{
//	HttpContext.Session.SetString("username", writer.WriterEmail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//	return View();
//}
