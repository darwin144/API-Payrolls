using System.ComponentModel.DataAnnotations;

namespace API_Payroll.ViewModels.Accounts
{
    public class ResetPasswordVM
    {
        public int OTP { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
