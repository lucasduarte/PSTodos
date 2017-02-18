namespace PSTodos.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigsCascadeOnUsuarioPerfil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.USUARIO_PERFIL", "ID_USUARIO", "dbo.USUARIO");
            AddForeignKey("dbo.USUARIO_PERFIL", "ID_USUARIO", "dbo.USUARIO", "ID_USUARIO", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USUARIO_PERFIL", "ID_USUARIO", "dbo.USUARIO");
            AddForeignKey("dbo.USUARIO_PERFIL", "ID_USUARIO", "dbo.USUARIO", "ID_USUARIO");
        }
    }
}
