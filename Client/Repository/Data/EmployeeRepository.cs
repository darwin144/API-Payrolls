using Client.Models;

using Client.Repository.Interface;
using Client.Repository.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
    {
       
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
        }

        public async Task<ResponseViewModel<EmployeeDTO>> GetEmployeeById(Guid Id, string token)
        {
			
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
			ResponseViewModel<EmployeeDTO> employeeResponse = null;
            using (var response = await httpClient.GetAsync(_request + Id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employeeResponse = JsonConvert.DeserializeObject<ResponseViewModel<EmployeeDTO>>(apiResponse);
            }

            return employeeResponse;
        }
        public async Task<ResponseListVM<ListEmployeeVM>> GetAllEmployee()
        {
            ResponseListVM<ListEmployeeVM> entityVM = null;
            using (var response = httpClient.GetAsync(_request + "GetAllMasterEmployee").Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseListVM<ListEmployeeVM>>(apiResponse);
            }
            return entityVM;
        }

        
    }
}
