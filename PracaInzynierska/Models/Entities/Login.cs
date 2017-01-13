using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Logins")]
    public class Login
    {
        [Key, ForeignKey("User")]
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Proszę podać login")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Proszę podać hasło")]
        [MaxLength(50)]
        public string Password { get; set; }
        //used for relation 1:1
        public virtual User User { get; set; }
    }
}
