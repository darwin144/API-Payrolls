using API_eSIP.Context;
using API_eSIP.Contracts;
using API_eSIP.Models;

namespace API_eSIP.Repositories
{
    public class EmployeeOvertimeRepository : GenericRepository<Overtime>, IEmployeeOvertimeRepository
    {
        public EmployeeOvertimeRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
