using API_eSIP.Context;
using API_eSIP.Contracts;
using API_eSIP.Models;

namespace API_eSIP.Repositories
{
    public class AccountRoleRepository : GenericRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
