using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.ViewModels.Overtimes;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class OvertimeController : BaseController<Overtime, OvertimeVM>
    {
        private readonly IEmployeeOvertimeRepository _overtimeRepository;
        private readonly IMapper<Overtime, OvertimeVM> _mapper;

        public OvertimeController(IEmployeeOvertimeRepository overtimeRepository, IMapper<Overtime, OvertimeVM> mapper) : base(overtimeRepository, mapper)
        {
            _overtimeRepository = overtimeRepository;
            _mapper = mapper;
        }
    }
}
