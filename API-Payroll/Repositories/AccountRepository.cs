using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;

namespace API_Payroll.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
