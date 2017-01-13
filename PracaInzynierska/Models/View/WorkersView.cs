using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.View
{
    [Table("V_WorkersView")]
    public class WorkersView
    {
       [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string NameRole { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCodeNumber { get; set; }
        public string PositionName { get; set; }

        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfRelease { get; set; }

    }
}
