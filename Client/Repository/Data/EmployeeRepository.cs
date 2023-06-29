using Client.Models;
using Client.Repositories;
using Client.Repository.Interface;
using Client.Repository.Interface;
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
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
        }
		
		public EmployeeRepository(string request = "Employee/"): base(request)
		{
		
		}
		public async Task<string> CreateRequest(Overtime overtime) {

			/*var accessToken = HttpContext.Session.GetString("JWToken");
			var url = request;
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
			await client.PostAsync(url, stringContent);
*/
			return "";
		}

    }
}
