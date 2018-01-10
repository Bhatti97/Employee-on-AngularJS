namespace AngularJs_with_webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee_Education",
                c => new
                    {
                        Employee_Education_id = c.Int(nullable: false, identity: true),
                        Employee_Education_DegreeName = c.String(),
                        Employee_Education_DegreeYear = c.String(),
                        Employee_Education_University = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Education_TotalMarks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Education_ObtainedMarks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Education_Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_Education_id)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee_Education", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Employee_Education", new[] { "Employee_id" });
            DropTable("dbo.Employee_Education");
        }
    }
}
