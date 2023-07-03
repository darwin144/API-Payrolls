using API_Payroll.Models;
using API_Payroll.ViewModels.Overtimes;
using System.Data;

namespace API_Payroll.Contracts
{
    public interface IEmployeeOvertimeRepository : IGenericRepository<Overtime>
    {
        Overtime CreateRequest(Overtime overtime);
        int ApprovalOvertime(Overtime overtime,Guid id);
        List<OvertimeVM> ListOvertimeByIdManager(Guid idManager);
        IEnumerable<OvertimeVM> ListOvertimeByIdEmployee(Guid idEmployee);

        IEnumerable<OvertimeRemainingVM> ListRemainingOvertime();
        IEnumerable<OvertimeRemainingVM> ListRemainingOvertimeByGuid(Guid id);
        OvertimeRemainingVM RemainingOvertimeByEmployeeGuid(Guid id);
        ChartManagerVM DataChartByGuid(Guid id);
    }
}
