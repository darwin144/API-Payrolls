using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
    public interface IDepartmentRepository : IRepository<Department, Guid>
    {
        /*public Task<ResponseListVM<Department>> GetAllDepartments();*/
    }
}
