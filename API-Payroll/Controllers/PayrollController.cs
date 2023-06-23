using API_Payroll.Contracts;
using API_Payroll.Controllers;
using API_Payroll.Models;
using API_Payroll.ViewModels.Payrolls;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
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
