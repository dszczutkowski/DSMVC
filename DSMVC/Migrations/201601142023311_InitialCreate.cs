namespace DSMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Meals", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MealID", "dbo.Meals");
            DropIndex("dbo.Orders", new[] { "MealID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Meals");
        }
    }
}
