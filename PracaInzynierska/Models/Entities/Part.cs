using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Parts")]
    public class Part
    {
        public Part()
        {

            this.Defects = new HashSet<Defect>();
        }
        [Key]
        public int PartId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CatalogName { get; set; }

        public virtual ICollection<Defect> Defects { get; set; }
    }
}
