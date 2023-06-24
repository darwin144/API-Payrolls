using API_Payroll.Contracts;
using API_Payroll.Controllers;
using API_Payroll.Models;
using API_Payroll.ViewModels.Others;
using API_Payroll.ViewModels.Payrolls;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class PayrollController : BaseController<Payroll, PayrollPrintVM>
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly IMapper<Payroll, PayrollPrintVM> _mapper;

        public PayrollController(IPayrollRepository payrollRepository, IMapper<Payroll, PayrollPrintVM> mapper) : base (payrollRepository, mapper)
        {
            _payrollRepository = payrollRepository;
            _mapper = mapper;
        }
        [HttpPost("CreatePayroll")]
        public IActionResult Create(PayrollCreateVM viewModel) {
            try
            {
                var result = _payrollRepository.CreatePayroll(viewModel);
                if (result is null)
                {
                    return NotFound(new ResponseVM<PayrollCreateVM>
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Gagal Ditambahkan"
                    });
                }
                return Ok(new ResponseVM<Payroll>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data Berhasil Ditambahkan",
                    Data = result
                });
            }
            catch {
                return BadRequest();
            }

        }
    }
}
