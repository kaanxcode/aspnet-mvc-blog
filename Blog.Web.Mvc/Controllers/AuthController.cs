using Blog.Business.Dtos;
using Blog.Business.Services.Abstract;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace Blog.Web.Mvc.Controllers
{
	public class AuthController : Controller
	{
		private readonly IUserService _userService;

		public AuthController(IUserService us)
		{
			_userService = us;
		}

		public IActionResult Register() => View();

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (HttpContext.User.Identity.IsAuthenticated) return Redirect("/");
			if (ModelState.IsValid)
			{
				_userService.Insert(new UserDto { Name = model.Name, Email = model.Email, Password = model.Password, Phone = model.Phone != null ? model.Phone : "", City = model.City != null ? model.City : "" });
				return RedirectToAction(nameof(Login));
			}
			else
			{
				return View(model);
			}
		}


		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (HttpContext.User.Identity.IsAuthenticated) return Redirect("/");

			if (ModelState.IsValid)
			{
				var user = _userService.GetByEmailPassword(model.Email, model.Password);
				if (user != null)
				{
					var props = new AuthenticationProperties() { ExpiresUtc = DateTime.UtcNow.AddMinutes(60) };

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, _userService.ConvertToPrincipal(user), props);
					if (!user.Roles.IsNullOrEmpty() && user.Roles.Contains("Admin")) return Redirect("/Admin/home");
					return Redirect("/");
				}
				else
				{
					ViewBag.Error = "E-Mail veya şifre yanlış";
				}
			}

			return View(model);
		}

		public IActionResult Logout()
		{
			HttpContext.SignOutAsync();
			return Redirect("/");
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}