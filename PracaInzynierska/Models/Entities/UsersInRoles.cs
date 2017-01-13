using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_UsersInRoles")]
    public class UsersInRoles
    {        
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
