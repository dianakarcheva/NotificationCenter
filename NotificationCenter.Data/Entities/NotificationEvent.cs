using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationCenter.Data.Enums;

namespace NotificationCenter.Data.Entities
{
    public class NotificationEvent
    {
        [Key]
        public long Id { get; set; }

        [StringLength(35)]
        [Required]
        public string EventName { get; set; }

        [Required]
        public NotificationRaiseCriteria RaiseCriteria { get; set; }

        [Required]
        public ClientType TargetGroup { get; set; }

        [Required]
        public NotificationChannel Channel { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
