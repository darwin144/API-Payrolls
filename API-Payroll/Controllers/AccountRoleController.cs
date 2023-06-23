using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.ViewModels.AccountRoles;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class AccountRoleController : BaseController<AccountRole, AccountRoleVM>
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMapper<AccountRole, AccountRoleVM> _mapper;

        public AccountRoleController(IAccountRoleRepository accountRoleRepository, IMapper<AccountRole, AccountRoleVM> mapper) : base(accountRoleRepository, mapper)
        {
            _accountRoleRepository = accountRoleRepository;
            _mapper = mapper;
        }
    }
}
