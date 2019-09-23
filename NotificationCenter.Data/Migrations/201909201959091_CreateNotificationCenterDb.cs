namespace NotificationCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNotificationCenterDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientCertificates",
                c => new
                    {
                        ClientId = c.Long(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 35),
                        Password = c.String(nullable: false),
                        Salt = c.String(nullable: false),
                        ClientType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncomingNumber = c.String(nullable: false),
                        ClientId = c.Long(nullable: false),
                        EnquiryType = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.NotificationEvents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 35),
                        RaiseCriteria = c.Int(nullable: false),
                        TargetGroup = c.Int(nullable: false),
                        Channel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquiries", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientCertificates", "ClientId", "dbo.Clients");
            DropIndex("dbo.Enquiries", new[] { "ClientId" });
            DropIndex("dbo.ClientCertificates", new[] { "ClientId" });
            DropTable("dbo.NotificationEvents");
            DropTable("dbo.Enquiries");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientCertificates");
        }
    }
}
