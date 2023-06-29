using Client.Models;
using Client.Repositories.Interface;

using Client.ViewModels;

namespace Client.Repository.Interface
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        /*public Task<ResponseListVM<ListEmployeeVM>> GetAllEmployees();*/
    }
}

	public interface IEmployeeRepository : IGeneralRepository<Employee, Guid>
	{

	}
}
