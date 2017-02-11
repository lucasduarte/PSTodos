using PSTodos.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PSTodos.Infrastructure.Repository.EF
{
    internal class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("USUARIO");

            Property(x => x.Id)
                .HasColumnName("ID_USUARIO")
                .IsRequired();

            Property(x => x.Login)
                .HasColumnName("LOGIN")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_USUARIO_LOGIN", 1) { IsUnique = true }));

            Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_USUARIO_EMAIL", 2) { IsUnique = true }));

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(250);

            Property(x => x.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            Property(x => x.DtInclusao)
                .HasColumnName("DT_INCLUSAO")
                .IsRequired();

            this.HasKey<int>(x => x.Id);
        }
    }
}