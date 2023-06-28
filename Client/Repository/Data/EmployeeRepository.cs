using Client.Models;
using System.Net;

namespace Client.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>
    {
		
		public EmployeeRepository(string request = "Employee/"): base(request)
		{
		
		}
		public async Task<string> CreateRequest() {
			
			
			return "";
		}

    }
}
