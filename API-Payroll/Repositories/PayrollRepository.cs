using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.Utilities.Enum;
using API_Payroll.ViewModels.Payrolls;

namespace API_Payroll.Repositories
{
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(PayrollOvertimeContext context) : base(context)
        {
        }

        public Payroll CreatePayroll(PayrollCreateVM payrollCreate) {
            try
            {
                var today = DateTime.Today;
                var targetDate = new DateTime(today.Year, today.Month, 25);

                if (payrollCreate.PayDate.Day == targetDate.Day)
                {
                    var employeeLevel = _context.Employees.Where(a => a.Id == payrollCreate.Employee_id)
                                .Join(_context.EmployeeLevels, e => e.EmployeeLevel_id, el => el.Id, (e, el) => new { e.EmployeeLevel, el.Employees })
                                .FirstOrDefault();
                    var allowence = employeeLevel.EmployeeLevel.Allowence;
                    var salary = employeeLevel.EmployeeLevel.Salary;
                    var overtime = _context.Overtimes.Where(a => a.Employee_id == payrollCreate.Employee_id && a.SubmitDate.Day <= targetDate.Day && a.Status == Status.Approved)
                                    .Select(a => a.Paid).Sum();

                    var pph = 0.0042 * salary;
                    var bpjs = (salary + allowence) * 0.01;
                    var totalCuts = pph + bpjs;
                    var totalSalary = salary + overtime + allowence - totalCuts;

                    var model = new Payroll
                    {
                        Id = payrollCreate.Id,
                        PayDate = payrollCreate.PayDate,
                        PayrollCuts = Convert.ToInt32(totalCuts),
                        TotalSalary = Convert.ToInt32(totalSalary),
                        Employee_id = payrollCreate.Employee_id
                    };

                    _context.Set<Payroll>().Add(model);
                    _context.SaveChanges();
                    return model;
                }
                return null;
            }
            catch {
                return null;
            }
        }
        
    }
}
