using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;

namespace API_Payroll.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(PayrollOvertimeContext context) : base(context)
        {
        }
    }
}
