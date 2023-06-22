using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        [Column("name",TypeName ="varchar(20)")]
        public string Name {get; set;}
    }
}
