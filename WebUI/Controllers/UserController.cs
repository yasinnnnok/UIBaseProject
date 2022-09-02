﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
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
            var values = _userService.GetList().Data;
            return View(values);
        }

     
 

        public IActionResult Delete(int id)
        {
            var user= _userService.GetById(id).Data;
            _userService.Delete(user);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _userService.GetById(id).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            UserValidator validationRules = new UserValidator();
            ValidationResult validationResult = validationRules.Validate(user);

            if (validationResult.IsValid)
            {

                _userService.Update(user);
                return RedirectToAction("Index", "User");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult ChangePassword(int id)
        {
            var result = _userService.GetById(id).Data;
            UserChangePasswordDto changePasswordDto = new UserChangePasswordDto();
            changePasswordDto.UserId = result.Id;
            return View(changePasswordDto);
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            var result= _userService.ChangePassword(userChangePasswordDto);
            if (result.Success)
            {
                return RedirectToAction("Login", "Auth");
            }

            TempData["Hata"] = result.Message;
            return View();
        }


    }
}
