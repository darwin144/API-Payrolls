using API_eSIP.Context;
using API_eSIP.Contracts;
using API_eSIP.Models;

namespace API_eSIP.Repositories
{
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
