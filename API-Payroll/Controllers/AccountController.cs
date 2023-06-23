using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.ViewModels.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class AccountController : BaseController<Account, AccountVM>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper<Account, AccountVM> _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper<Account, AccountVM> mapper) : base(accountRepository, mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;

        }
    }
}
