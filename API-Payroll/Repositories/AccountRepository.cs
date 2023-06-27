﻿using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.Utilities;
using API_Payroll.ViewModels.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace API_Payroll.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AccountRepository(PayrollOvertimeContext context, IEmployeeRepository employeeRepository) : base(context)
        {
            _employeeRepository = employeeRepository;
        }
        public int ChangePasswordAccount(Guid? employeeId, ChangePasswordVM changePasswordVM)
        {
            var account = _context.Set<Account>().FirstOrDefault(a => a.Id == employeeId);

            //check value of property
            if (account == null || account.OTP != changePasswordVM.OTP) return 2;
            if (account.IsUsed) return 3;
            if (account.ExpiredTime < DateTime.Now) return 4;
            if (changePasswordVM.NewPassword != changePasswordVM.ConfirmPassword) return 5;

            account.Password = changePasswordVM.NewPassword;
            account.IsUsed = true;
            try
            {
                var updatePassword = Update(account);
                if (!updatePassword)
                {
                    return 0;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<string>>? GetRoles(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            var getRoles = await _context.AccountRoles
                .Where(
                ar => ar.Account_id == employee.Id)
                .Join(_context.Roles,
                ar => ar.Role_id,
                r => r.Id,
                (ar, r) => r.Name)
                .ToListAsync();

            return getRoles;
        }

        public async Task<UserDateVM> GetUserData(string email)
        {
            return await _context.Employees.Select(e => new UserDateVM
            {
                GuidEmployee = e.Id.ToString(),
                Email = e.Email,
                FullName = String.Concat(e.FirstName, " ", e.LastName),
            }).FirstOrDefaultAsync(e => e.Email == email);


            
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var query = await(from emp in _context.Employees
                              join acc in _context.Accounts
                              on emp.Id equals acc.Id
                              select new LoginVM
                              {
                                  Email = emp.Email,
                                  Password = acc.Password

                              }).FirstOrDefaultAsync(e => e.Email == loginVM.Email);

            if (query is null)
            {
                return false;
            }
            //validate password with hashing 
            return Hashing.ValidatePassword(loginVM.Password, query.Password);
        }

        public async Task<int> Register(RegisterVM registerVM)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var month = DateTime.Now.Month;
                    var countNIK = _context.Employees.OrderByDescending(e => e.NIK).FirstOrDefault();

                    if (countNIK == null)
                    {
                        registerVM.NIK = month + "111" + 1;
                    }
                    else
                    {
                        registerVM.NIK = Convert.ToString(Convert.ToUInt32(countNIK.NIK) + 1);
                    }
                    var employee = new Employee
                    {
                        NIK = registerVM.NIK,
                        FirstName = registerVM.FirstName,
                        LastName = registerVM.LastName,
                        BirthDate = registerVM.BirthDate,
                        Gender = registerVM.Gender,
                        HiringDate = registerVM.HiringDate,
                        Email = registerVM.Email,
                        PhoneNumber = registerVM.PhoneNumber,
                        ReportTo = registerVM.ReportTo,
                        EmployeeLevel_id = registerVM.EmployeeLevel_id,
                        Department_id = registerVM.Department_id,
                    };
                    //validate input employee
                    var results = _employeeRepository.CreateWithValidate(employee);
                    if (results != 3) return results;

                    var account = new Account
                    {
                        Id = employee.Id,
                        Employee_id = employee.Id,
                        Password = Hashing.HashPassword(registerVM.Password),
                        IsDeleted = false,
                        IsUsed = true,
                        OTP = 0
                    };
                    Create(account);

                    var accountRole = new AccountRole
                    {
                        Role_id = Guid.Parse("f147a695-1a4f-4960-bffc-08db60bf618f"),
                        Account_id = account.Id
                    };

                    await _context.AccountRoles.AddAsync(accountRole);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return 3;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int UpdateOTP(Guid? employeeId)
        {
            var account = _context.Set<Account>().FirstOrDefault(a => a.Employee_id == employeeId);
            //Generate OTP
            Random rnd = new Random();
            var getOtp = rnd.Next(100000, 999999);
            account.OTP = getOtp;

            //Add 5 minutes to expired time
            account.ExpiredTime = DateTime.Now.AddMinutes(15);
            account.IsUsed = false;
            try
            {
                var check = Update(account);
                if (!check)
                {
                    return 0;
                }
                return getOtp;
            }
            catch
            {
                return 0;
            }

        }
    }
}
