using Client.Models;
using Client.Repository.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Client.Repository.Data
{
	public class OvertimeRepository : GeneralRepository<Overtime, Guid>, IOvertimeRepository
	{
		public OvertimeRepository(string request="Overtime/") : base(request)
		{

		}

		public Task<int> ApprovalOvertime()
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseListVM<IEnumerable<Overtime>>> GetOvertimeByemployeeGuid(Guid id)
		{
			ResponseListVM<IEnumerable<Overtime>> overtimes = null;

			using (var response = await httpClient.GetAsync(_request + "ByEmployee/" + id))
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				overtimes = JsonConvert.DeserializeObject<ResponseListVM<IEnumerable<Overtime>>>(apiResponse);
			}
			return overtimes;
		}		

		public async Task<ResponseMessageVM> RequestOvertime(Overtime overtime)
		{

			ResponseMessageVM entityVM = null;
			StringContent content = new StringContent(JsonConvert.SerializeObject(overtime), Encoding.UTF8, "application/json");
			using (HttpResponseMessage response = await httpClient.PostAsync(_request +"OvertimeRequest/", content))
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				entityVM = JsonConvert.DeserializeObject<ResponseMessageVM>(apiResponse);
			}
			return entityVM;
		}
	}
}
