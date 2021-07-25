namespace Budget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Desription = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            DropTable("dbo.Expenses");
        }
    }
}
