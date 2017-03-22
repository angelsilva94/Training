namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReviewProducts", "ratingReview", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReviewProducts", "ratingReview", c => c.Int(nullable: false));
        }
    }
}
