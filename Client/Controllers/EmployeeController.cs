using Client.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Request()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOvertime(Overtime overtime) {
            
                        
            return View();
        }
    }
}
