using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.View
{
   [Table("V_ClientsOrderView")]
    public class ClientsOrderView
    {
        [Key]
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartRepair { get; set; }
        public DateTime EndOfRepair { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public double SerivecePrice { get; set; }
        
            

    }
}
