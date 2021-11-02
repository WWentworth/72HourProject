namespace _72HourProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostController : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
        }
    }
}
