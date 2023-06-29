using Client.Models;
using Client.Repository.Data;
using Client.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Client.Controllers
{
    /*    [Authorize(Roles = "Employee")]
    */
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IEmployeeRepository repository;

        public AdminController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Payroll()
        {
            return View();
        }

        public async Task<IActionResult> ListEmployee()
        {
            var result = await repository.Get();
            var employees = new List<Employee>();

            if (result.Data != null)
            {
                employees = result.Data?.Select(e => new Employee
                {
                    Id = e.Id,
                    NIK = e.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    HiringDate = e.HiringDate,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    ReportTo = e.ReportTo,
                    EmployeeLevel_id = e.EmployeeLevel_id,
                    Department_id = e.Department_id,
                }).ToList();
            }
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Create(Employee employee)
        {
            /*if (ModelState.IsValid)
            {*/
            //daaru general repo
            var result = await repository.Post(employee);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListEmployee));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
                /* }*/
            }
            return RedirectToAction(nameof(ListEmployee));
        }

        public async Task<IActionResult> Deletes(Guid Id)
        {
            var result = await repository.Get(Id);
            var employee = new Employee();
            if (result.Data?.Id is null)
            {
                return View(employee);
            }
            else
            {
                employee.Id = result.Data.Id;
                employee.NIK = result.Data.NIK;
                employee.FirstName = result.Data.FirstName;
                employee.LastName = result.Data.LastName;
                employee.BirthDate = result.Data.BirthDate;
                employee.Gender = result.Data.Gender;
                employee.HiringDate = result.Data.HiringDate;
                employee.Email = result.Data.Email;
                employee.PhoneNumber = result.Data.PhoneNumber;
                employee.ReportTo = result.Data.ReportTo;
                employee.EmployeeLevel_id = result.Data.EmployeeLevel_id;
                employee.Department_id = result.Data.Department_id;

            }
            return View(employee);
        }
        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Remove(Guid Id)
        {
            var result = await repository.Deletes(Id);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListEmployee));
            }
            return RedirectToAction(nameof(ListEmployee));
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Edit(Employee employee)
        {
            /*if (ModelState.IsValid)
            {*/
            var result = await repository.Put(employee);
            /*if(result != null) { */
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListEmployee));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
                /*}*/

            }
            return RedirectToAction(nameof(ListEmployee));
        }
        [HttpGet]
        /* [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Edit(Guid Id)
        {
            var result = await repository.Get(Id);
            var employee = new Employee();
            if (result.Data?.Id is null)
            {
                return View(employee);
            }
            else
            {
                employee.Id = result.Data.Id;
                employee.NIK = result.Data.NIK;
                employee.FirstName = result.Data.FirstName;
                employee.LastName = result.Data.LastName;
                employee.BirthDate = result.Data.BirthDate;
                employee.Gender = result.Data.Gender;
                employee.HiringDate = result.Data.HiringDate;
                employee.Email = result.Data.Email;
                employee.PhoneNumber = result.Data.PhoneNumber;
                employee.ReportTo = result.Data.ReportTo;
                employee.EmployeeLevel_id = result.Data.EmployeeLevel_id;
                employee.Department_id = result.Data.Department_id;
            }

            return View(employee);
        }
    }
}

