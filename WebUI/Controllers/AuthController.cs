using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm]AuthDto authDto)
        {
            var result= _authService.Register(authDto);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["Hata"] = result.Message;
            return View(authDto);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginAuthDto loginAuthDto)
        {
            var result = _authService.Login(loginAuthDto);
            if (result.Success)
            {
                JwtSecurityTokenHandler handler =new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(result.Data.AccessToken);

                ClaimsIdentity identity = new ClaimsIdentity(token.Claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties();

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);

                return RedirectToAction("Index", "Home");
            }
            TempData["LoginHata"] = result.Message;
            return View();
        }

      
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
