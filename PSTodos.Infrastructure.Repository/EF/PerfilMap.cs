using PSTodos.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PSTodos.Infrastructure.Repository.EF
{
    internal class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("PERFIL");

            Property(x => x.Id)
                .HasColumnName("ID_PERFIL")
                .IsRequired();

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            HasKey<int>(x => x.Id);
        }
    }
}
