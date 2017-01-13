using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_CarInqueries")]
    public class CarInquery
    {
        //public CarInquery()
        //{
        //    this.Orders = new HashSet<Order>();
        //}
        [Key]
        public int CarRequestId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<int> OrderId { get; set; }
        public virtual Order Order { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        //used for relation 1:1
        public virtual ReplacementCar ServicesCar { get; set; }
    }
}
