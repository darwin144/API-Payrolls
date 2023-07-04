
using Client.Repository.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Client.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly HomeRepository _repository;

       /* private readonly EmployeeLevelRepository _employeeLevelRepository;
        private readonly DepartmentRepository _departmentRepository;*/

        public HomeController(HomeRepository repository)
        {
            _repository = repository;
           /* _employeeLevelRepository = employeeLevelRepository;
            _departmentRepository = departmentRepository;*/
        }

        public IActionResult Dashboard()
        {

            return View();
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var jwtToken = await _repository.Logins(login);

            if (jwtToken == null || jwtToken.Data == null)
            {
                TempData["ErrorMessage"] = "Email or password is incorrect.";
                return RedirectToAction("Login", "Home");
            }
            var token = jwtToken.Data;
            var claim = ExtractClaims(token);
            var roleClaim = claim.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            var role = roleClaim != null ? roleClaim.Value : null;
            var idClaim = claim.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid");
            var id = idClaim != null ? idClaim.Value : null;
            if (token == null)
            {
                return RedirectToAction("forgotpassword", "Home");
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("id", id);


            if (role.Contains("Employee"))
            {
                return RedirectToAction("Profile", "Employee");
            }
            else if (role.Contains("Manager"))
            {
                return RedirectToAction("Index", "Manager");
            }
            else if (role.Contains("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IEnumerable<Claim> ExtractClaims(string jwtToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);
            IEnumerable<Claim> claims = securityToken.Claims;
            return claims;
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Dashboard", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
           /* var empLevel = await _employeeLevelRepository.Get();
            var deptName = await _departmentRepository.Get();
            ViewBag.empLevel=empLevel.Data;
            ViewBag.departmentName=deptName.Data;
*/

            return View();
        }

        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            var result = await _repository.Registers(registerVM);


            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["Error"] = $"Something Went Wrong! - {result.Message}!";
                return View();
            }
            else if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Dashboard", "Home");


        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        /*  [HttpGet("Unauthorized/")]
          public IActionResult Unauthorized()
          {
              return View("401");
          }

          [HttpGet("Forbidden/")]
          public IActionResult Forbidden()
          {
              return View("403");
          }

          [HttpGet("Notfound/")]
          public IActionResult Notfound()
          {
              return View("404");
          }*/
        [AllowAnonymous]
        [HttpGet("/Unauthorized")]
        public IActionResult Unauthorized()
        {
            return View("401");
        }

        [AllowAnonymous]
        [HttpGet("/notfound")]
        public IActionResult NotFound()
        {
            return View("404");
        }

        [AllowAnonymous]
        [HttpGet("/forbidden")]
        public IActionResult Forbidden()
        {
            return View("403");
        }

        /*[HttpPost]
        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await _repository.Auth(login);
            var token = jwtToken.IdToken;
            var claim = ExtractClaims(token);
            var role = claim.Where(claim => claim.Type == "role").Select(s => s.Value).ToList();
            var nik = claim.Where(claim => claim.Type == "nik").Select(s => s.Value).Single();

            if (token == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("nik", nik);



            if (role.Contains("Finance"))
            {
                return RedirectToAction("index", "finance");
            }
            else if (role.Contains("Manager"))
            {
                return RedirectToAction("index", "manager");
            }
            else
            {
                return RedirectToAction("index", "employee");
            }
        }

        public IEnumerable<Claim> ExtractClaims(string jwtToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);
            IEnumerable<Claim> claims = securityToken.Claims;
            return claims;
        }*/
    }
}