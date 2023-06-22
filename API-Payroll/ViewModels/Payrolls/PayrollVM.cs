using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.ViewModels.Payrolls
{
    public class PayrollVM
    {
        public Guid Id { get; set; }
        
        public float Tax { get; set; }
        
        public DateTime PayDate { get; set; }
        
        public int PayrollCuts { get; set; }
        
        public int TotalSalary { get; set; }
        public Guid Employee_id { get; set; }

    }
}
