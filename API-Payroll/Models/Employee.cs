using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.Models
{
    [Table("tb_m_employees")]
    public class Employee
    {

        [Key]
        public Guid Id { get; set; }
        [Column("nik", TypeName = "nchar(6)")]
        public string NIK { get; set; }
        [Column("first_name", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Column("last_name", TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("gender",TypeName="char(1)")]
        public string Gender { get; set; }
        [Column("hiring_date")]
        public DateTime HiringDate { get; set; }
        [Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column("phone_number", TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Column("reportTo")]
        public Guid ReportTo { get; set; }
        [Column("employeeLevel_id")]
        public Guid EmployeeLevel_id { get; set; }
        [Column("department_id")]
        public Guid Department_id { get; set; }
        [Column("overtime_id")]
        public Guid Overtime_id { get; set; }

        //kardinalitas

    }
}
