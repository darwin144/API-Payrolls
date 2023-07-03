﻿using Client.Models;

using Client.Repository.Interface;
using Client.ViewModels;
using Client.ViewModels.Payroll;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repository.Data
{
    public class PayrollRepository : GeneralRepository<Payroll, Guid>, IPayrollRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public PayrollRepository(string request = "Payroll/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7165/API-Payroll/")
            };
        }
        public async Task<ResponseListVM<PayrollPrintVM>> GetAllPayroll()
        {
            ResponseListVM<PayrollPrintVM> entityVM = null;
            using (var response = httpClient.GetAsync(request + "GetAllDetails").Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseListVM<PayrollPrintVM>>(apiResponse);
            }
            return entityVM;
        }
        public async Task<ResponseMessageVM> CreatePayroll(Payroll payroll)
        {
            ResponseMessageVM entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(payroll), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await httpClient.PostAsync(request + "CreatePayroll", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseMessageVM>(apiResponse);
            }
            return entityVM;
        }
    }
}
