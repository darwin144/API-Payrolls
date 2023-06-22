using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.ViewModels.Employees;
using API_eSIP.ViewModels.Payrolls;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class PayrollController : BaseController<Payroll, PayrollVM>
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly IMapper<Payroll, PayrollVM> _mapper;

        public PayrollController(IPayrollRepository payrollRepository, IMapper<Payroll, PayrollVM> mapper) : base (payrollRepository, mapper)
        {
            _payrollRepository = payrollRepository;
            _mapper = mapper;
        }
    }
}
