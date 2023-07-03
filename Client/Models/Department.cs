using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        
       
        public string Name { get; set; }
    }
}
