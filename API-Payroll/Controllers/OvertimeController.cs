using API.Utility;
using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.Repositories;
using API_eSIP.ViewModels.Overtimes;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class OvertimeController : BaseController<Overtime,OvertimeVM>
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
