﻿using API_eSIP.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.Models
{
    [Table("tb_m_overtimes")]
    public class Overtime
    {
        [Key]
        public Guid Id { get; set; }
        [Column("submitDate")]
        public DateTime SubmitDate { get; set; }
        [Column("deskripsi",TypeName ="varchar(50)")]
        public string Deskripsi { get; set; }
        [Column("Paid")]
        public int Paid { get; set; }
        [Column("tipe")]
        public Types Tipe { get; set; }
        [Column("status")]
        public Status Status { get; set; }
        [Column("type")]
        public Types Type { get; set; }       

        //kardinalitas
    }
}