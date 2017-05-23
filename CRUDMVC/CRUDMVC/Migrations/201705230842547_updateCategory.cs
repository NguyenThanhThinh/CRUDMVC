namespace CRUDMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Category", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Description", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String(maxLength: 100));
        }
    }
}
