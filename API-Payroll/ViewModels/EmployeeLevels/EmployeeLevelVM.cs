using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.ViewModels.EmployeeLevels
{
    public class EmployeeLevelVM
    {

        public Guid Id { get; set; }
 
        public string TitleName { get; set; }
        
        public string Level { get; set; }
        
        public int Salary { get; set; }
    }
}
