
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
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Client.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly HomeRepository _repository;

        public HomeController(HomeRepository repository)
        {
            _repository = repository;
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
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Logins(LoginVM login)
        {
            var result = await _repository.Logins(login);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", result.Data);
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        public IActionResult Register()
        {
            return View();
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
    }
}
