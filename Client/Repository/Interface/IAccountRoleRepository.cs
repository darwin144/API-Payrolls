using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
	public interface IAccountRoleRepository : IRepository<AccountRole, Guid>
	{
		public Task<ResponseListVM<ListAccountRoleVM>> GetAllMasterAccountRole();
	}
}
