using API_Payroll.Contracts;
using API_Payroll.Controllers;
using API_Payroll.Models;
using API_Payroll.ViewModels.EmployeeLevels;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
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
