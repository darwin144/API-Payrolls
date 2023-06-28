using Client.Models;

namespace Client.Repository.Data
{
	public class OvertimeRepository : GeneralRepository<Overtime, Guid>
	{
		public OvertimeRepository(string request="Overtime/") : base(request)
		{
		}
	}
}
