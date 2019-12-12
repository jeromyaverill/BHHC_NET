namespace BHHC_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuestionAnswer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionAnswers");
        }
    }
}
