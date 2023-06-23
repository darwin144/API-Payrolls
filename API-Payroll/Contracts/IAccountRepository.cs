using API_Payroll.Models;
using System.Security.Principal;

namespace API_Payroll.Contracts
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    }
}
