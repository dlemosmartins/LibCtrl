

using LibDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LibDDD.Infra.Data.EntityConfig
{
    public class LibConfiguration: EntityTypeConfiguration<Livro>
    {
        public LibConfiguration()
        {
            HasKey(x => x.LivroID);
            Property(x => x.Observacao)
                .HasMaxLength(255);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(x => x.Autor)
                .WithMany()
                .HasForeignKey(x=> x.AutorId);

            HasRequired(x => x.Editora)
                .WithMany()
                .HasForeignKey(x => x.EditoraId);
        }
    }
}
