using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.ViewModels.AccountRoles
{
    public class AccountRoleVM
    {
        public Guid Id { get; set; }
        public Guid Account_id { get; set; }
        public Guid Role_id { get; set; }
    }
}
