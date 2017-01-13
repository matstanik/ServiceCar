using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Orders")]
    public class Order
    {
        public Order()
        {
            
            this.Defects = new HashSet<Defect>();
            this.CarInquery = new HashSet<CarInquery>();
        }
        [Key]
        public int OrderId { get; set; }
        public double SerivecePrice { get; set; }
        public double Milage { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartRepair { get; set; }
        public DateTime EndOfRepair { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        //public Nullable<int> DefectId { get; set; }
        //used for relation 1:M
        public Nullable<int> WorkerId { get; set; }
        public Nullable<int> CarId { get; set; }
        //public Nullable<int> CarRequestId { get; set; }
        //used for relation 1:M
        public Nullable<int> ClientId { get; set; }
        public virtual Client Client { get; set; }
        //public virtual CarInquery CarInqueries { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<CarInquery> CarInquery { get; set; }
        //public virtual Defect Defect { get; set; }
        [NotMapped]
        public virtual ICollection<Defect> Defects { get; set; }
    }
}
