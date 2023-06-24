using API_Payroll.Models;
using API_Payroll.ViewModels.Payrolls;

namespace API_Payroll.Contracts
{
    public interface IPayrollRepository : IGenericRepository<Payroll>
    {
        Payroll CreatePayroll(PayrollCreateVM payrollCreate);
    }
}
