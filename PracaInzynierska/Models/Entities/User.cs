using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }    
        public string NameRole { get; set; }
        [Required(ErrorMessage ="Proszę podaj Imię")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(40)]
        public string Sex { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Podaj nazwę ulicy")]
        [MaxLength(50)]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Podaj numer budynku")]
        [MaxLength(50)]
        public string HouseNumber { get; set; }
        //used for relation 1:1
        public virtual Login Login { get; set; }
        [NotMapped]
        public virtual Role Role { get; set; }      
        public virtual Worker Worker { get; set; } 
        public virtual Client Client { get; set; }
        public virtual PostalCode PostalCode { get; set; }
    }
}
