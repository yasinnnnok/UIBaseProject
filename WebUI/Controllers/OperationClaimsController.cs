using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OperationClaimsController : Controller
    {
        private readonly IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }
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
            _operationClaimService.Add(operationClaim);
            return RedirectToAction("Index", "OperationClaims");
        }


        public IActionResult Delete(int id)
        {
            var operationClaim = _operationClaimService.GetById(id);
            _operationClaimService.Delete(operationClaim);
            return RedirectToAction("Index", "OperationClaims");
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
            _operationClaimService.Update(operationClaim);
            return RedirectToAction("Index", "OperationClaims");
        }


    }
}
