namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class realrealdbSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "DateRegistered", c => c.DateTime());
            AlterColumn("dbo.Students", "DateRegistered", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateRegistered", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Registrations", "DateRegistered", c => c.DateTime(nullable: false));
        }
    }
}
