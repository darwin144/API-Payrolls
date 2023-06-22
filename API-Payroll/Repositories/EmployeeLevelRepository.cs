using API_eSIP.Context;
using API_eSIP.Contracts;
using API_eSIP.Models;

namespace API_eSIP.Repositories
{
    public class EmployeeLevelRepository : GenericRepository<EmployeeLevel>, IEmployeeLevelRepository
    {
        public EmployeeLevelRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
