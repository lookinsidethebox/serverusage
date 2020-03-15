namespace ServerUsage.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServerHistories",
                c => new
                    {
                        VirtualServerId = c.Int(nullable: false, identity: true),
                        CreateDateTime = c.DateTime(nullable: false),
                        RemoveDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.VirtualServerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServerHistories");
        }
    }
}
