using Client.Models;
using Client.Repositories;
using Client.Repository.Interface;

namespace Client.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
        }
    }
}
