namespace BHHC_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestion1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Questions", "QuestionTypeId");
            AddForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
        }
    }
}
