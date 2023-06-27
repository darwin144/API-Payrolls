using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.ViewModels.Accounts
{
    public class AccountVM
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public Guid Employee_id { get; set; }


    }
}
