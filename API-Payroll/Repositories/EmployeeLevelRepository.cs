using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.Repositories;

namespace API_Payroll.Repositories
{
    public class EmployeeLevelRepository : GenericRepository<EmployeeLevel>, IEmployeeLevelRepository
    {
        public EmployeeLevelRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
