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
        private readonly IUserService _userService;

        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService, IUserService userService)
        {
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
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
            UserDto userOperation = new UserDto();
            userOperation.Id = result.Id;
            userOperation.UserId = result.UserId;
            userOperation.OperationClaimId = result.OperationClaimId;
            var user = _userService.GetById(result.UserId);
            userOperation.KullaniciAdi = user.Data.Name;
            


            return View(userOperation);
        }

        [HttpPost]
        public IActionResult Update(UserDto userDto)
        {

           var result=  _userOperationClaimService.Update(userDto);
           
            if (result.Success)
            {
                return RedirectToAction("Index", "UserOperationClaim");
            }
            TempData["Hata"] = result.Message;
            return View(userDto);

        }


    }
}
   