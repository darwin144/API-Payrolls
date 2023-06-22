using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_eSIP.ViewModels.Roles
{
    public class RoleVM
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
