using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("DIC_PostalCodes")]
    public class PostalCode
    {
        [Key, ForeignKey("UserId")]
        public int PostalCodeId { get; set; }
        public string PostalCodeNumber { get; set; }
        public string City { get; set; }
        public virtual User UserId { get; set; }
    }
}
