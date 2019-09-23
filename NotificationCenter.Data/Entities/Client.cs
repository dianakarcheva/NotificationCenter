using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.Data.Entities
{
    public class Client
    {
        [Key]
        public long Id { get; set; }

        [StringLength(35)]
        [MinLength(5)]
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public ClientType ClientType { get; set; }

        public ICollection<Enquiry> Enquiries { get; set; }

        public ClientCertificate Certificate { get; set; }
    }
}
