using Client.Models;

using Client.Repository.Interface;
using Client.Repository.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
            this.request = request;

        }

        public async Task<ResponseViewModel<EmployeeDTO>> GetEmployeeById(Guid Id)
        {
            ResponseViewModel<EmployeeDTO> employeeResponse = null;
            using (var response = await httpClient.GetAsync(request + Id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employeeResponse = JsonConvert.DeserializeObject<ResponseViewModel<EmployeeDTO>>(apiResponse);
            }

            return employeeResponse;
        }


        
    }
}
