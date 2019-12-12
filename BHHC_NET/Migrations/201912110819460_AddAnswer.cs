namespace BHHC_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        CandidateAnswer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "CandidateId" });
            DropTable("dbo.Answers");
        }
    }
}
