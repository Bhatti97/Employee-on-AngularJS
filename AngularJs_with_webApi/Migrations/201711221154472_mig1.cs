namespace AngularJs_with_webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee_Education", "Employee_Education_University", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee_Education", "Employee_Education_University", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
