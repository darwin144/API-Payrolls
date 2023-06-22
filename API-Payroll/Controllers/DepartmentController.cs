using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.Repositories;
using API_eSIP.ViewModels.Departments;
using API_eSIP.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
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
