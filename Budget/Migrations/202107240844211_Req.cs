﻿namespace Budget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Req : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String());
        }
    }
}
