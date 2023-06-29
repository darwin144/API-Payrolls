using Client.Models;
using Client.ViewModels;

namespace Client.Repository.Interface
{
	public interface IHomeRepository : IGeneralRepository<Account, string>
	{
		public Task<ResponseViewModel<string>> Logins(LoginVM entity);
		/*        public Task<ResponseMessageVM> Registers(RegisterVM entity);
		*/
	}
}