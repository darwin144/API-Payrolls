
using Client.Models;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repository.Data
{
    public class HomeRepository : GeneralRepository<Account, int>
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeRepository(string request = "Account/") : base(request)
        {
/*            _contextAccessor = new HttpContextAccessor();
*/            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
            this.request = request;

        }

        public async Task<ResponseViewModel<string>> Logins(LoginVM entity)
        {
            ResponseViewModel<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseViewModel<string>>(apiResponse);
            }
            return entityVM;
        }

    }
}
