using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.Models
{
    [Table("tb_m_employeeLevels")]
    public class EmployeeLevel
    {
        [Key]
        public Guid Id { get; set; }
        [Column("titleName", TypeName ="Varchar(50)")]
        public string TitleName { get; set; }
        [Column("level", TypeName = "Varchar(20)")]
        public string Level { get; set; }
        [Column("salary")]
        public int Salary { get; set; }
    }
}
