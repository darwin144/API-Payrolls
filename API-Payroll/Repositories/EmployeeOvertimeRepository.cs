using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;

namespace API_Payroll.Repositories
{
    public class EmployeeOvertimeRepository : GenericRepository<Overtime>, IEmployeeOvertimeRepository
    {
        public EmployeeOvertimeRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
