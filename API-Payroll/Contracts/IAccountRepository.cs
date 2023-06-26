﻿using API_Payroll.Models;
using API_Payroll.ViewModels.Accounts;
using System.Security.Principal;

namespace API_Payroll.Contracts
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<int> Register(RegisterVM registerVM);
        int ChangePasswordAccount(Guid? employeeId, ChangePasswordVM changePasswordVM);
        Task<bool> Login(LoginVM loginVM);
        int UpdateOTP(Guid? employeeId);
        Task<UserDateVM> GetUserData(string email);
        Task<List<string>>? GetRoles(string email);
    }
}
