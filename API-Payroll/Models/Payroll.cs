using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.Models
{
    [Table("tb_tr_payrolls")]
    public class Payroll
    {
        [Key]
        public Guid Id { get; set; }
        [Column("payDate")]
        public DateTime PayDate { get; set; }
        [Column("payrollCut")]
        public int PayrollCuts { get; set; }
        [Column("totalSalary")]
        public int TotalSalary { get; set; }
        [Column("employee_id")]
        public Guid Employee_id { get; set; }

        // kardinalitas
        public Employee? Employee { get; set; }
    }
}
