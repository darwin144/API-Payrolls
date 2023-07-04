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
        public readonly IHttpContextAccessor _contextAccessor;


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

        public async Task<ResponseListVM<ListEmployeeVM>> GetAllEmployee()
        {
            ResponseListVM<ListEmployeeVM> entityVM = null;
            using (var response = httpClient.GetAsync(request + "GetAllMasterEmployee").Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseListVM<ListEmployeeVM>>(apiResponse);
            }
            return entityVM;
        }

        
    }
}
