using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Payroll.ViewModels.Departments
{
    public class DepartmentVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
