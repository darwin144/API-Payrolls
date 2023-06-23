using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;

namespace API_Payroll.Repositories
{
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
