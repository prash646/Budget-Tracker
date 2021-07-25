namespace Budget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Req2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Expenses", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "Desription", c => c.String(nullable: false));
            DropColumn("dbo.Expenses", "Description");
        }
    }
}
