using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
    public interface IManagerRepository : IRepository<Manager, Guid>
    {
        Task<ResponseViewModel<EmployeeDTO>> GetEmployeeById(Guid Id);
    }
}


