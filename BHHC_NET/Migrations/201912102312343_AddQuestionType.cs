namespace BHHC_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionTypes");
        }
    }
}
