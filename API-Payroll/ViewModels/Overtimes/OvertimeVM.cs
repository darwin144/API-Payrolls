﻿using API_Payroll.Utilities.Enum;

namespace API_Payroll.ViewModels.Overtimes
{
    public class OvertimeVM
    {
        public Guid Id { get; set; }
        public DateTime StartOvertime { get; set; }
        public DateTime EndOvertime { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Deskripsi { get; set; }
        public int Paid { get; set; }
        //update to string
        public Status Status { get; set; }
        public Guid Employee_id { get; set; }
    }
}
