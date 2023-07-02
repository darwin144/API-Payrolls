﻿using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? ReportTo { get; set; }
        public Guid EmployeeLevel_id { get; set; }
        public Guid Department_id { get; set; }
    }

}
