using Business.Abstract;
using Entities.Concrete;
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
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimService.Add(userOperationClaim);
            return RedirectToAction("Index", "UserOperationClaim");
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
            _userOperationClaimService.Update(userOperationClaim);
            return RedirectToAction("Index", "UserOperationClaim");
        }


    }
}
