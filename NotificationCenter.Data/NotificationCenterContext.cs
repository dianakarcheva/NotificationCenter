using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using NotificationCenter.Data.Entities;

namespace NotificationCenter.Data
{
    public class NotificationCenterContext: DbContext
    {
        public NotificationCenterContext() : base("name=NotificationCenterContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOptional(c => c.Certificate)
                .WithRequired(c => c.Client);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<ClientCertificate> ClientCertificates { get; set; }

        public virtual DbSet<Enquiry> Enquiries { get; set; }

        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }
    }
}
