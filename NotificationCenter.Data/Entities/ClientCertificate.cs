using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.Data.Entities
{
    public class ClientCertificate
    {
        [Key]
        public long ClientId { get; set; }

        [Required]
        public string SetialNumber { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

    }
}
