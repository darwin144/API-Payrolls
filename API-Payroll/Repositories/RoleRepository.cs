using API_eSIP.Context;
using API_eSIP.Contracts;
using API_eSIP.Models;

namespace API_eSIP.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
