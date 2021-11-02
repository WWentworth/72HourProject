namespace _72HourProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplyControllerGetAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "CommentId" });
            AddColumn("dbo.Comments", "CommentId", c => c.Int());
            AddColumn("dbo.Comments", "ReplyText", c => c.String());
            AddColumn("dbo.Comments", "ReplyAuthorId", c => c.Guid());
            AddColumn("dbo.Comments", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "CommentId");
            AddForeignKey("dbo.Comments", "CommentId", "dbo.Comments", "Id");
            DropTable("dbo.Replies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Comments", "CommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "CommentId" });
            DropColumn("dbo.Comments", "Discriminator");
            DropColumn("dbo.Comments", "ReplyAuthorId");
            DropColumn("dbo.Comments", "ReplyText");
            DropColumn("dbo.Comments", "CommentId");
            CreateIndex("dbo.Replies", "CommentId");
            AddForeignKey("dbo.Replies", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
        }
    }
}
