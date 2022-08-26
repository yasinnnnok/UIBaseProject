using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.GetList();
            return View(values);
        }

     
 

        public IActionResult Delete(int id)
        {
            var user= _userService.GetById(id);
            _userService.Delete(user);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _userService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return RedirectToAction("Index", "User");
        }


    }
}
