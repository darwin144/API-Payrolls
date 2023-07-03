using Client.Models;

using Client.Repository.Interface;

namespace Client.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, Guid>, IAccountRoleRepository
    {

        public AccountRoleRepository(string request = "AccountRole/") : base(request)
        {
        }
        /*private readonly HttpClient httpClient;
        private readonly string request;


        public AccountRoleRepository(string request = "AccountRole/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
        }*/
    }
}
