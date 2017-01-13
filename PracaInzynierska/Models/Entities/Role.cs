using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Roles")]
    public class Role
    {
        [Key, ForeignKey("User")]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        //Used for relation 1:1
        public virtual User User { get; set; }
    }
}
