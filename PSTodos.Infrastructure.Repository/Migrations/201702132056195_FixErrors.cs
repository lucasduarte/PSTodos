namespace PSTodos.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixErrors : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.USUARIO_PERFIL");
            AddPrimaryKey("dbo.USUARIO_PERFIL", new[] { "ID_PERFIL", "ID_USUARIO" });
            DropColumn("dbo.USUARIO_PERFIL", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USUARIO_PERFIL", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.USUARIO_PERFIL");
            AddPrimaryKey("dbo.USUARIO_PERFIL", new[] { "Id", "ID_PERFIL", "ID_USUARIO" });
        }
    }
}
