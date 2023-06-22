using API_eSIP.Models;
using Microsoft.EntityFrameworkCore;

namespace API_eSIP.Context
{
    public class PayrollOvertimeContext : DbContext
    {
        public PayrollOvertimeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
