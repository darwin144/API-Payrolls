using API_Payroll.Utilities;

namespace API_Payroll.Contracts
{
    public interface IEmailService 
    {
        void SendEmailAsync();
        MailService SetEmail(string email);
        MailService SetSubject(string subject);
        MailService SetHtmlMessage(string htmlMessage);
    }
}
