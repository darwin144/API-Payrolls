using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.ViewModels.Accounts;
using API_eSIP.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class AccountController : BaseController<Account,AccountVM>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper<Account, AccountVM> _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper<Account, AccountVM> mapper) : base (accountRepository, mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;

        }
    }
}
