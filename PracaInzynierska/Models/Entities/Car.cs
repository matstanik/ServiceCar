using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Cars")]
    public class Car
    {
        public Car()
        {
            //this.Owners = new HashSet<Owner>();
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        public double Capacity { get; set; }
        public string EngineType { get; set; }
        public DateTime BornYear { get; set; }
        public Nullable<int> ClientId { get; set; }
        public virtual Client Client { get; set; }
        //public Nullable<int> ClientId { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual ICollection<Owner> Owners { get; set; }
        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
