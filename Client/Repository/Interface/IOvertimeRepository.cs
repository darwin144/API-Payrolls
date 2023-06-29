using Client.Models;
using Client.ViewModels;
using Client.ViewModels.Overtime;

namespace Client.Repository.Interface
{
	public interface IOvertimeRepository : IGeneralRepository<Overtime, Guid>
	{
		Task<ResponseMessageVM> RequestOvertime(Overtime overtime);
        Task<IEnumerable<OvertimeDetailVM>> GetOvertimeByemployeeGuid(Guid id);
		Task<int> ApprovalOvertime();

	}
}
