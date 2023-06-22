using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.Models
{
    [Table("tb_m_accounts")]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("employee_id")]
        public Guid Employee_id { get; set; }

    }
}
