namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afaf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "IsActive");
        }
    }
}
