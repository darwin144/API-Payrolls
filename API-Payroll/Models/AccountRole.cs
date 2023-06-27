﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.Models
{
    [Table("tb_tr_accountRoles")]
    public class AccountRole
    {
        [Key]
        public Guid Id { get; set; }
        [Column("account_id")]
        public Guid Account_id { get; set; }
        [Column("role_id")]
        public Guid Role_id { get; set; }

        //kardinalitas
        public Role? Role { get; set; }
        public Account? Account { get; set; }
    }
}
