using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OperationClaimsController : Controller
    {
        private readonly IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }
        
        
       
     
        [HttpGet]
        public IActionResult Index()
        {
            var values = _operationClaimService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OperationClaim operationClaim)
        {

            var result = _operationClaimService.Add(operationClaim);
            if (result.Success)
            {
                return RedirectToAction("Index", "OperationClaims");
            }

            TempData["Hata"] = result.Message;
            return View(operationClaim);
        }


        public IActionResult Delete(int id)
        {

            var operationClaim = _operationClaimService.GetById(id);
            var result = _operationClaimService.Delete(operationClaim);

            if (result.Success)
            {
                return RedirectToAction("Index", "OperationClaims");
            }
            TempData["RolSilHata"] = result.Message;
            return RedirectToAction("Index", "OperationClaims", TempData["Hata"]);

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _operationClaimService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(OperationClaim operationClaim)
        {
            OperationClaimsValidator validationRules = new OperationClaimsValidator();
            ValidationResult result = validationRules.Validate(operationClaim);


            if (result.IsValid)
            {
                _operationClaimService.Update(operationClaim);
                return RedirectToAction("Index", "OperationClaims");
            }
            return View(operationClaim);
        }


    }
}
