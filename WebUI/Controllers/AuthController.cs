using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
            _authService.Register(authDto);
            return RedirectToAction("Index","User");                 
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginAuthDto loginAuthDto)
        {
            var result = _authService.Login(loginAuthDto);
            if (result)
            {
                return RedirectToAction("Register", "Auth");
            }
            TempData["LoginHata"]= "Hatalı Giriş";
            return View();
          
        }
    }
}
