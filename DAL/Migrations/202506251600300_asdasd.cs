namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tokens", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "UserType", c => c.String());
        }
    }
}
