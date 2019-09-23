using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.Data.Entities
{
    public class Notification
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Message { get; set; }

        public long? ReferenceRecord { get; set; }

        [Required]
        public bool Seen { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public long NotificationEventId { get; set; }

        [ForeignKey("NotificationEventId")]
        public virtual NotificationEvent NotificationEvent { get; set; }
    }
}
