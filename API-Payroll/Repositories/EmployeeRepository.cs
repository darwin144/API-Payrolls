using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.Repositories;

namespace API_Payroll.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
