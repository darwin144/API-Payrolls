﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    /*    [Authorize(Roles = "Employee")]
    */
    [AllowAnonymous]
    public class AdminController : Controller
    {
		public IActionResult Payroll()
		{
			return View();
		}
		public IActionResult ListEmployee()
        {
            return View();
        }
    }
}