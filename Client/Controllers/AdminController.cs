using Client.Models;
using Client.Repository.Interface;
using Client.ViewModels;
using Client.ViewModels.Payroll;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;


namespace Client.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    /*[AllowAnonymous]*/
    public class AdminController : Controller
    {
        private readonly IEmployeeRepository repository;
        private readonly IPayrollRepository payrollRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IAccountRoleRepository accountRoleRepository;

        public AdminController(IEmployeeRepository repository, IPayrollRepository payrollRepository, IDepartmentRepository departmentRepository, IAccountRoleRepository accountRoleRepository)
        {
            this.repository = repository;
            this.payrollRepository = payrollRepository;
            this.departmentRepository = departmentRepository;
            this.accountRoleRepository = accountRoleRepository;
        }

        public async Task<IActionResult> Payroll()
        {
            /*return View();*/
            var result = await payrollRepository.Get();
            var payrolls = new List<Payroll>();

            if (result.Data != null)
            {
                payrolls = result.Data?.Select(p => new Payroll
                {
                    Id = p.Id,
                    PayDate = p.PayDate,
                    PayrollCuts = p.PayrollCuts,
                    TotalSalary = p.TotalSalary,
                    Employee_id = p.Employee_id
                }).ToList();
            }
            return View(payrolls);
        }

        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetAllPayroll()
        {
           

            var result = await payrollRepository.GetAllPayroll();
            var getAllPayroll = new List<PayrollPrintVM>();

            if (result.Data != null)
            {
                getAllPayroll = result.Data.Select(e => new PayrollPrintVM
                {
                    Id = e.Id,
                    PayDate = e.PayDate,
                    Fullname = e.Fullname,
                    Department = e.Department,
                    Title = e.Title,
                    Allowence = e.Allowence,
                    Overtime = e.Overtime,
                    PayrollCuts = e.PayrollCuts,
                    TotalSalary = e.TotalSalary,
                }).ToList();
            }
            return View(getAllPayroll);
        }




        
        [HttpGet]
        public async Task<IActionResult> CreatePayroll()
        {
            return View();
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreatePayroll(Payroll payroll)
        {
            var result = await payrollRepository.CreatePayroll(payroll);
            if (result.Code == 200)
            {
                TempData["successMessage"] = "Data Berhasil Disubmit";
                return RedirectToAction(nameof(GetAllPayroll));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(GetAllPayroll));
        }

        public async Task<IActionResult> DeletePayroll(Guid Id)
        {
            var result = await payrollRepository.Get(Id);
            var payroll = new Payroll();
            if (result.Data?.Id is null)
            {
                return View(GetAllPayroll);
            }
            else
            {
                payroll.Id = result.Data.Id;
                payroll.PayDate = result.Data.PayDate;
                payroll.PayrollCuts = result.Data.PayrollCuts;
                payroll.TotalSalary = result.Data.TotalSalary;
                payroll.Employee_id = result.Data.Employee_id;
            }
            return View(GetAllPayroll);
        }
        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> RemovePayroll(Guid Id)
        {
            var result = await payrollRepository.Deletes(Id);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(GetAllPayroll));
            }
            return RedirectToAction(nameof(GetAllPayroll));
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> EditPayroll(Payroll payroll)
        {
            var result = await payrollRepository.Put(payroll);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(GetAllPayroll));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(GetAllPayroll));
        }
        [HttpGet]
        /* [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> EditPayroll(Guid Id)
        {
            var result = await payrollRepository.Get(Id);
            var payroll = new Payroll();
            if (result.Data?.Id is null)
            {
                return View(GetAllPayroll);
            }
            else
            {
                payroll.Id = result.Data.Id;
                payroll.PayDate = result.Data.PayDate;
                payroll.PayrollCuts = result.Data.PayrollCuts;
                payroll.TotalSalary = result.Data.TotalSalary;
                payroll.Employee_id = result.Data.Employee_id;
            }

            return View(GetAllPayroll);
        }




        //Employee

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

        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetAllEmployee()
        {

            

            var result = await repository.GetAllEmployee();
            var getAllEmployee = new List<ListEmployeeVM>();

            if (result.Data != null)
            {
                getAllEmployee = result.Data.Select(e => new ListEmployeeVM
                {
                    Id = e.Id,
                    NIK = e.NIK,
                    FullName = e.FullName,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    HiringDate = e.HiringDate,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    ReportTo = e.ReportTo,
                    Title = e.Title,
                    DepartmentName = e.DepartmentName,
                }).ToList();
            }
            return View(getAllEmployee);
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
            var result = await repository.Post(employee);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(GetAllEmployee));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(GetAllEmployee));
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
                return RedirectToAction(nameof(GetAllEmployee));
            }
            return RedirectToAction(nameof(GetAllEmployee));
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Edit(Employee employee)
        {
            var result = await repository.Put(employee);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(GetAllEmployee));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(GetAllEmployee));
        }
        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
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

        /*[Authorize(Roles = "Admin")]*/
        //Department
        public async Task<IActionResult> ListDepartment()
        {
           

            var result = await departmentRepository.Get();
            var departments = new List<Department>();

            if (result.Data != null)
            {
                departments = result.Data?.Select(e => new Department
                {
                    Id = e.Id,
                    Name = e.Name,

                }).ToList();
            }
            return View(departments);
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            var result = await departmentRepository.Post(department);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListDepartment));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(ListDepartment));
        }

        public async Task<IActionResult> DeleteDepartment(Guid Id)
        {
            var result = await departmentRepository.Get(Id);
            var department = new Department();
            if (result.Data?.Id is null)
            {
                return View(department);
            }
            else
            {
                department.Id = result.Data.Id;
                department.Name = result.Data.Name;
            }
            return View(department);
        }
        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> RemoveDepartment(Guid Id)
        {
            var result = await departmentRepository.Deletes(Id);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListDepartment));
            }
            return RedirectToAction(nameof(ListDepartment));
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> EditDepartment(Department department)
        {
            var result = await departmentRepository.Put(department);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListDepartment));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(ListDepartment));
        }
        [HttpGet]
        /* [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> EditDepartment(Guid Id)
        {
            var result = await departmentRepository.Get(Id);
            var department = new Department();
            if (result.Data?.Id is null)
            {
                return View(department);
            }
            else
            {
                department.Id = result.Data.Id;
                department.Name = result.Data.Name;
            }

            return View(department);
        }

        /*[Authorize(Roles = "Admin")]*/
        //AccountRole
        public async Task<IActionResult> ListAccountRole()
        {
            var result = await accountRoleRepository.Get();
            var accountRoles = new List<AccountRole>();

            if (result.Data != null)
            {
                accountRoles = result.Data?.Select(e => new AccountRole
                {
                    Id = e.Id,
                    Account_id = e.Account_id,
                    Role_id = e.Role_id,

                }).ToList();
            }
            return View(accountRoles);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAccountRole()
        {
            return View();
        }


        [HttpPost("CreateAcccountRole")]
        public async Task<IActionResult> CreateAcccountRole(AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRoleRepository.Post(accountRole);
                if (result.Code == 200)
                {
                    return RedirectToAction(nameof(ListAccountRole));
                }
                else if (result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }
            return RedirectToAction(nameof(ListAccountRole));
        }

        [HttpGet]
        public async Task<IActionResult> EditAccountRole(Guid Id)
        {
            var result = await accountRoleRepository.Get(Id);
            var accountRole = new AccountRole();
            if (result.Data?.Id is null)
            {
                return View(accountRole);
            }
            else
            {
                accountRole.Id = result.Data.Id;
                accountRole.Account_id = result.Data.Account_id;
                accountRole.Role_id = result.Data.Role_id;
            }

            return View(accountRole);
        }


        [HttpPost]
        public async Task<IActionResult> EditAccountRole(AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRoleRepository.Put(accountRole);
                if (result.Code == 200)
                {
                    return RedirectToAction(nameof(ListAccountRole));
                }
                else if (result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }
            return RedirectToAction(nameof(ListAccountRole));
        }

        public async Task<IActionResult> DeletesAccountRole(Guid Id)
        {
            var result = await accountRoleRepository.Get(Id);
            var accountRole = new AccountRole();
            if (result.Data?.Id is null)
            {
                return View(accountRole);
            }
            else
            {
                accountRole.Id = result.Data.Id;
                accountRole.Account_id = result.Data.Account_id;
                accountRole.Role_id = result.Data.Role_id;

            }
            return View(accountRole);
        }


        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> RemoveAccountRole(Guid Id)
        {
            var result = await accountRoleRepository.Deletes(Id);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(ListAccountRole));
            }
            return RedirectToAction(nameof(ListAccountRole));
        }
    }
}

