using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.Repositories;

namespace API_Payroll.Repositories
{
    public class AccountRoleRepository : GenericRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
