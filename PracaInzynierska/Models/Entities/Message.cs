using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models.Entities
{
    [Table("TB_Messages")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        public string MessageContent { get; set; }
        public Nullable<int> ClientId { get; set; }
        //used for relation 1:M
        public virtual Client Client{get;set;}
        //used for relation 1:M

    }
}
