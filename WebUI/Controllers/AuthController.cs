using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthDto authDto)
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
                return RedirectToAction("Index", "Home");
            }
            TempData["LoginHata"] = result.Message;
            return View();
        }
    }
}
