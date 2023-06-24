﻿using API_Payroll.Models;
using API_Payroll.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Payroll.Models
{
    [Table("tb_m_overtimes")]
    public class Overtime
    {
        [Key]
        public Guid Id { get; set; }
        [Column("startOvertime")]
        public DateTime StartOvertime { get; set; }
        [Column("endOvertime")]
        public DateTime EndOvertime { get; set; }
        [Column("submitDate")]
        public DateTime SubmitDate { get; set; }
        [Column("deskripsi", TypeName = "varchar(50)")]
        public string Deskripsi { get; set; }
        [Column("Paid")]
        public int Paid { get; set; }
        [Column("status")]
        public Status Status { get; set; }
        [Column("employee_id")]
        public Guid Employee_id { get; set; }

        //kardinalitas
        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}
