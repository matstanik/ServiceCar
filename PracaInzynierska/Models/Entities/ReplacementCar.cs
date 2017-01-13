using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_ReplacementCars")]
    public class ReplacementCar
    {
        [Key, ForeignKey("CarInquery")]
        public int ServicesCarId { get; set; }
        [Required]
        public string Model { get; set;}
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        public double Capacity { get; set; }
        public string EngineType { get; set; }
        //used for relation 1:1
        public virtual CarInquery CarInquery { get; set; }
    }
}
