using PSTodos.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PSTodos.Infrastructure.Repository.EF
{
    internal class UsuarioPerfilMap : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilMap()
        {
            ToTable("USUARIO_PERFIL");

            Property(x => x.PerfilId)
                .HasColumnName("ID_PERFIL");

            Property(x => x.UsuarioId)
                .HasColumnName("ID_USUARIO");

            Property(x => x.Ativo)
                .HasColumnName("ATIVO");

            this.HasKey(x =>
                new
                {
                    x.Id,
                    x.PerfilId,
                    x.UsuarioId
                });

            this.HasRequired(x => x.Perfil)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PerfilId);

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.Perfis)
                .HasForeignKey(x => x.UsuarioId);

        }
    }
}