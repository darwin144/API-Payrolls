﻿using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
	public interface IOvertimeRepository : IGeneralRepository<Overtime, Guid>
	{
		Task<ResponseMessageVM> RequestOvertime(Overtime overtime);
		Task<ResponseListVM<IEnumerable<Overtime>>> GetOvertimeByemployeeGuid(Guid id);
		Task<int> ApprovalOvertime();

	}
}
