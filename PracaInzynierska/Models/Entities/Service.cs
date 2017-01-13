using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Services")]
    public class Service
    {
        public Service()
        {
            this.Defects = new HashSet<Defect>();
        }
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [NotMapped]
        public virtual ICollection<Defect> Defects { get; set; }
    }
}
