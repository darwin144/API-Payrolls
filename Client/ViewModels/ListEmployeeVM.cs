using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class ListEmployeeVM
    {
        public Guid Id { get; set; }
        public string NIK { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? ReportTo { get; set; }
        public Guid EmployeeLevel_id { get; set; }
        public Guid DepartmentName_id { get; set; }
    }
}
