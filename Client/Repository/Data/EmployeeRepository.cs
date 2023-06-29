using Client.Models;
using Client.Repository.Interface;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
    {
		
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
