﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
/*    [Authorize(Roles = "Manager")]
*/
/*    [AllowAnonymous]
*/    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
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
