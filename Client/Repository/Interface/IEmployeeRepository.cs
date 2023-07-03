using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        /*public Task<ResponseListVM<ListEmployeeVM>> GetAllEmployees();*/
        Task<ResponseViewModel<EmployeeDTO>> GetEmployeeById(Guid Id);
        public Task<ResponseListVM<ListEmployeeVM>> GetAllEmployee();
    }
}


