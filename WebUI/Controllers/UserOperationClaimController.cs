using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserOperationClaimController : Controller
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;

        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService, IUserService userService, IOperationClaimService operationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
            _operationClaimService = operationClaimService;
        }

        //[AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpGet]
   
        public IActionResult Index()
        {
            var values = _userOperationClaimService.GetList();
            
            return View(values);
        }

        
       // [Authorize(Roles = "Admin")]
        [HttpGet]

        public IActionResult Add()
        {
           var userList = _userService.GetList().Data.ToList();
           var operationList = _operationClaimService.GetList().ToList();
      

            return View((new UserDto(),operationList, userList));
        }

        [HttpPost]
        public IActionResult Add([Bind(Prefix = "Item1")] UserDto userDto)
        {
            var result = _userOperationClaimService.Add(userDto);
            if (result.Success)
            {
                return RedirectToAction("Index", "UserOperationClaim");
            }
            TempData["Hata"] = result.Message;
            var userList = _userService.GetList().Data.ToList();
            var operationList = _operationClaimService.GetList().ToList();
            return View((userDto, operationList, userList));

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
            var user = _userService.GetById(result.UserId);

            UserDto userOperation = new UserDto();
            userOperation.Id = result.Id;
            userOperation.UserId = result.UserId;
            userOperation.OperationClaimId = result.OperationClaimId;            
            userOperation.KullaniciAdi = user.Data.Name;
            var operationList = _operationClaimService.GetList().ToList();


            return View((userOperation, operationList));
            //return View((new UserDto(), operationList, userOperation));

         
        }
       

        [HttpPost]
        public IActionResult Update([Bind(Prefix ="Item1")] UserDto userDto)
        {

           var result=  _userOperationClaimService.Update(userDto);
           
            if (result.Success)
            {
                return RedirectToAction("Index", "UserOperationClaim");
            }
            TempData["Hata"] = result.Message;
            
            var operationList = _operationClaimService.GetList().ToList();
            return View((userDto, operationList));

        }


    }
}
   