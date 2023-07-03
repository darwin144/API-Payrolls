using Client.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
  /*  [Authorize(Roles = "Manager")]*/

    /*    [AllowAnonymous]
    */
    public class ManagerController : Controller
    {
        private readonly IEmployeeRepository _repository;

		public ManagerController(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
        {
			var token = HttpContext.Session.GetString("JWToken");
			var claim = _repository.ExtractClaims(token);
			var guidEmployee = claim.Where(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid").Select(s => s.Value).Single();
			
            ViewData["guidEmployee"] = guidEmployee;
			ViewData["token"] = token;

			return View();
        }
        public IActionResult List()
        {
            var token = HttpContext.Session.GetString("JWToken");
            var claim = _repository.ExtractClaims(token);
            var guidEmployee = claim.Where(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid").Select(s => s.Value).Single();

            ViewData["guidEmployee"] = guidEmployee;
            ViewData["token"] = token;
            return View();
        } 
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Payslip()
        {
            return View();
        }
    }
}
