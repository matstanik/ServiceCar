using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.View
{
    [Table("V_DefectView")]
    public class DefectsView
    {
        [Key]
        public int DefectId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
