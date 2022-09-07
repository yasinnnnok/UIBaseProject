using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserOperationClaimController : Controller
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }


        public IActionResult Index()
        {
            var values = _userOperationClaimService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {

            var result = _userOperationClaimService.Add(userDto);
            if (result.Success)
            {
                return RedirectToAction("Index", "UserOperationClaim");
            }
            TempData["Hata"] = result.Message;
            return View(userDto);

        }

        public IActionResult Delete(int id)
        {
            var operationClaim = _userOperationClaimService.GetById(id);
            _userOperationClaimService.Delete(operationClaim);
            return RedirectToAction("Index", "UserOperationClaim");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _userOperationClaimService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            //UserOperationClaimValidator validationRules = new UserOperationClaimValidator();
            //ValidationResult result = validationRules.Validate(userOperationClaim);
            //if (result.IsValid)
            //{
                _userOperationClaimService.Update(userOperationClaim);
                return RedirectToAction("Index", "UserOperationClaim");
            //}
            //return View(userOperationClaim);
        }


    }
}
