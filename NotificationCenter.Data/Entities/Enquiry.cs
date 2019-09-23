using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.Data.Entities
{
    [Table("Enquiries")]
    public class Enquiry
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string IncomingNumber { get; set; }

        [Required]
        public long ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        public EnquiryType EnquiryType { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public EnquiryStatus State { get; set; }
    }
}
