using PSTodos.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PSTodos.Infrastructure.Repository.EF
{
    internal class OperacaoUsuarioMap : EntityTypeConfiguration<OperacaoUsuario>
    {
        public OperacaoUsuarioMap()
        {
            ToTable("OPERACAO_USUARIO");

            Property(x => x.Id)
                .HasColumnName("ID_OPERACAO_ACESSO")
                .IsRequired();

            Property(x => x.DtLog)
                .HasColumnName("DT_LOG")
                .IsRequired();

            Property(x => x.UsuarioId)
                .HasColumnName("ID_USUARIO");

            this.HasRequired<Usuario>(x => x.Usuario)
                .WithMany(u => u.OperacoesUsuario)
                .HasForeignKey(x => x.UsuarioId);

            this.HasKey(x => x.Id);    

        }
    }
}