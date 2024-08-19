namespace WebThoiTrang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaTBThongKe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThongKes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThoiGian = c.DateTime(nullable: false),
                        SoTruyCap = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Adv", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.tb_News", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
            DropColumn("dbo.tb_Posts", "ViewCount");
            DropColumn("dbo.tb_News", "ViewCount");
            DropColumn("dbo.tb_Adv", "ViewCount");
            DropTable("dbo.ThongKes");
        }
    }
}
