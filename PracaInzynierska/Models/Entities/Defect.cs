using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Defects")]
    public class Defect
    {
        //public Defect()
        //{
        //    this.Orders = new HashSet<Order>();
        //}
        [Key]
        public int DefectId { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> PartId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        //used for relation 1:M
        public virtual Order Order { get; set; }
        public virtual Part Part { get; set; }
        public virtual Service Service { get; set; }
    }
}
