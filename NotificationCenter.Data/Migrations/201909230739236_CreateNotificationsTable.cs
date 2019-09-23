namespace NotificationCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNotificationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        Message = c.String(nullable: false),
                        ReferenceRecord = c.Long(),
                        Seen = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        NotificationEventId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificationEvents", t => t.NotificationEventId, cascadeDelete: true)
                .Index(t => t.NotificationEventId);
            
            AddColumn("dbo.ClientCertificates", "SetialNumber", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Salt", c => c.String(nullable: false));
            DropForeignKey("dbo.Notifications", "NotificationEventId", "dbo.NotificationEvents");
            DropIndex("dbo.Notifications", new[] { "NotificationEventId" });
            DropColumn("dbo.ClientCertificates", "SetialNumber");
            DropTable("dbo.Notifications");
        }
    }
}
