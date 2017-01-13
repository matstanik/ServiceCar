using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Workers")]
    public class Worker
    {
        public Worker()
        {
            this.SalaryReports = new HashSet<SalaryReport>();
            this.Orders = new HashSet<Order>();
        }
        [Key, ForeignKey("User")]
        public int WorkerId { get; set; }
        public string PositionName { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfRelease { get; set; }
        //used for relation 1:1
        public virtual User User { get; set; }
        //used for relation 1:M
        public virtual ICollection<SalaryReport> SalaryReports { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}