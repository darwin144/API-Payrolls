using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;

namespace API_Payroll.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
