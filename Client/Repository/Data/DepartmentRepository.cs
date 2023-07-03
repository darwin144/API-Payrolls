using Client.Models;

using Client.Repository.Interface;
using Client.ViewModels;
using Newtonsoft.Json;

namespace Client.Repository.Data
{
    public class DepartmentRepository : GeneralRepository<Department, Guid>, IDepartmentRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public DepartmentRepository(string request = "Department/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
        }

        /*public async Task<ResponseListVM<Department>> GetAllDepartments()
        {
            ResponseListVM<Department> entityVM = null;
            using (var response = httpClient.GetAsync(request + "GetAllDepartments").Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseListVM<Department>>(apiResponse);
            }
            return entityVM;
        }*/
    }
}
