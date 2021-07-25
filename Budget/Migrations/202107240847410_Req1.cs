namespace Budget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Req1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            AlterColumn("dbo.Expenses", "Desription", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "Category_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "Category_ID");
            AddForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            AlterColumn("dbo.Expenses", "Category_ID", c => c.Int());
            AlterColumn("dbo.Expenses", "Desription", c => c.String());
            CreateIndex("dbo.Expenses", "Category_ID");
            AddForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
