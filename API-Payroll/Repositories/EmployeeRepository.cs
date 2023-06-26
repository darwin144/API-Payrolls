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
        public bool CheckValidation(string value)
        {
            return _context.Employees
            .Any(e => e.Email == value || e.PhoneNumber == value || e.NIK == value);
        }
        public Employee FindEmployeeByEmail(string email)
        {

            return _context.Set<Employee>().FirstOrDefault(a => a.Email == email);
        }

        public int CreateWithValidate(Employee employee)
        {
            try
            {
                bool ExistsByEmail = _context.Employees.Any(e => e.Email == employee.Email);
                if (ExistsByEmail)
                {
                    return 1;
                }

                bool ExistsByPhoneNumber = _context.Employees.Any(e => e.PhoneNumber == employee.PhoneNumber);
                if (ExistsByPhoneNumber)
                {
                    return 2;
                }

                Create(employee);
                return 3;
            }
            catch
            {
                return 0;
            }
        }
    }
}
