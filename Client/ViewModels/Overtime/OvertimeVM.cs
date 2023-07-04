﻿using Client.Utilities;
using Microsoft.Build.Framework;

namespace Client.ViewModels.Overtime
{
    public class OvertimeVM
    {
        public DateTime StartOvertime { get; set; }
        public DateTime EndOvertime { get; set; }
        public string SubmitDate { get; set; }
        public string Deskripsi { get; set; }
        public Status Status { get; set; }
    }
}
