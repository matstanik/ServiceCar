using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.View
{
    [Table("V_ClientsView")]
    public class ClientView
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string NameRole { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCodeNumber { get; set; }
        public bool CorporationClient { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
