﻿namespace API_Payroll.ViewModels.Overtimes
{
    public class OvertimeRemainingVM
    {
        public Guid Employee_id { get; set; }
        public string Fullname { get; set; }
        public int? RemainingOvertime {get;set;}
    }
}
