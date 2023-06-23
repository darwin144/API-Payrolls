using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.Models
{
    [Table("tb_m_departments")]
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
