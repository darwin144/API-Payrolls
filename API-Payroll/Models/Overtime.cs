﻿using API_Payroll.Models;
using API_Payroll.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.Models
{
    [Table("tb_m_overtimes")]
    public class Overtime
    {
        [Key]
        public Guid Id { get; set; }
        [Column("startOvertime")]
        public DateTime Start_Overtime { get; set; }
        [Column("endOvertime")]
        public DateTime End_Overtime { get; set; }
        [Column("submitDate")]
        public DateTime SubmitDate { get; set; }
        [Column("deskripsi", TypeName = "varchar(50)")]
        public string Deskripsi { get; set; }
        [Column("tipe")]
        public Types Tipe { get; set; }
        [Column("Paid")]
        public int Paid { get; set; }
        [Column("status")]
        public Status Status { get; set; }
        [Column("employee_id")]
        public Guid Employee_id { get; set; }

        //kardinalitas
        public Employee Employee { get; set; }
    }
}
