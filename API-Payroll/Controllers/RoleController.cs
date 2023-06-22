using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.ViewModels.Employees;
using API_eSIP.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
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
