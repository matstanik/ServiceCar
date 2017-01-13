using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_SalaryReport")]
    public class SalaryReport   
    {
        [Key]
        public int SalaryReportId { get; set; }
        [Required]
        public DateTime CountingStartTime { get; set; }
        [Required]
        public DateTime CountingEndTime { get; set; }
        [Required]
        public double Salary { get; set; }
        public double Bonus { get; set; }
        public Nullable<int> WorkerId { get; set; }
        //used for relation 1:M
        public virtual Worker Worker { get; set; }

    }
}
