using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    public class AccountRole
    {

        public Guid Id { get; set; }

        public Guid Account_id { get; set; }

        public Guid Role_id { get; set; }
    }
}
