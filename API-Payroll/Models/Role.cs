using API_Payroll.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        //kardinalitas
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}
