using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Clients")]
    public class Client
    {
        public Client()
        {
            this.Messages = new HashSet<Message>();
            //this.CarRequests = new HashSet<CarRequest>();
            this.Orders = new HashSet<Order>();
            //this.Owners = new HashSet<Owner>();
            this.Cars = new HashSet<Car>();
        }
        [Key, ForeignKey("User")]
        public int ClientId { get; set; }
        public bool CorporationClient { get; set; }
        public DateTime JoinDate { get; set; }
        [MaxLength(11)]
        public string NIP { get; set;}
        public string CompanyName { get; set; }
        //used for relation 1:1
        public virtual User User { get; set; }
        //used for relation 1:M
        public virtual ICollection<Message> Messages { get; set; }
        //used for relation 1:M
        //public virtual ICollection<CarRequest> CarRequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
