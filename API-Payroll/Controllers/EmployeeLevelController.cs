using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.ViewModels.EmployeeLevels;
using API_eSIP.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class EmployeeLevelController : BaseController<EmployeeLevel, EmployeeLevelVM>
    {

        private readonly IEmployeeLevelRepository _employeeLevelRepository;
        private readonly IMapper<EmployeeLevel, EmployeeLevelVM> _mapper;

        public EmployeeLevelController(IEmployeeLevelRepository employeeLevelRepository, IMapper<EmployeeLevel, EmployeeLevelVM> mapper) : base(employeeLevelRepository, mapper)
        {
            _employeeLevelRepository = employeeLevelRepository;
            _mapper = mapper;
        }
    }
}
