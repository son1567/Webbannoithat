namespace WebThoiTrang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentitySchema : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUserClaims", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_User_Id", newName: "IX_UserId");
            DropPrimaryKey("dbo.AspNetUserLogins");
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "Email");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "UserId", "LoginProvider", "ProviderKey" });
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");
        }
    }
}
