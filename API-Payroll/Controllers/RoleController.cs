using API_Payroll.Contracts;
using API_Payroll.Controllers;
using API_Payroll.Models;
using API_Payroll.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class RoleController : BaseController<Role, RoleVM>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper<Role, RoleVM> _mapper;

        public RoleController(IRoleRepository roleRepository, IMapper<Role, RoleVM> mapper) : base (roleRepository, mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
    }
}
