using LibDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Infra.Data.EntityConfig
{
    public class EditoraConfiguration : EntityTypeConfiguration<Editora>
    {
        public EditoraConfiguration()
        {
            HasKey(x => x.EditoraID);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(150);



        }

    }
}
