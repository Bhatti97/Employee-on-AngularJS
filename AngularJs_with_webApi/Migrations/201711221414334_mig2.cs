namespace AngularJs_with_webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Experience_id = c.Int(nullable: false, identity: true),
                        Experience_Companyname = c.String(),
                        Experience_Start_Year = c.String(),
                        Experience_End_Year = c.String(),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Experience_id)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Experiences", new[] { "Employee_id" });
            DropTable("dbo.Experiences");
        }
    }
}
