using Client.Models;
using Client.ViewModels;
using Client.ViewModels.Payroll;

namespace Client.Repository.Interface
{
    public interface IPayrollRepository : IRepository<Payroll, Guid>
    {
        public Task<ResponseListVM<PayrollPrintVM>> GetAllPayroll();
        Task<ResponseMessageVM> CreatePayroll(Payroll payroll);
    }
}
