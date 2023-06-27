using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.ViewModels.EmployeeLevels
{
    public class EmployeeLevelVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Level { get; set; }

        public int Salary { get; set; }

        public int? Allowence { get; set; }
    }
}
