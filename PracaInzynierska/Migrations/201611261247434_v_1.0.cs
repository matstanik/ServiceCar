namespace PracaInzynierska.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.View",
                c => new
                    {
                        klucz = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.klucz);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.View");
        }
    }
}
