using API_Payroll.Models;

namespace API_Payroll.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        bool CheckValidation(string value);
        Employee FindEmployeeByEmail(string email);
        int CreateWithValidate(Employee emloyee);
    }
}
