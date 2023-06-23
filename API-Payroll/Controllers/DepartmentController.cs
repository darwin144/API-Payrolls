using API_Payroll.Contracts;
using API_Payroll.Controllers;
using API_Payroll.Models;
using API_Payroll.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class DepartmentController : BaseController<Department, DepartmentVM>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper<Department, DepartmentVM> _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper<Department, DepartmentVM> mapper) : base(departmentRepository, mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
    }
}
