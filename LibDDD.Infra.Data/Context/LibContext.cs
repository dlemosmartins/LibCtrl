

using LibDDD.Domain.Entities;
using LibDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace LibDDD.Infra.Data.Context
{
    public class LibContext : DbContext
    {
        public LibContext()
      : base("name=LibDBHBSIS")
        {
            // the terrible hack
            var ensureDLLIsCopied =
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Editora> Editoras  { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(x => x.Name == x.ReflectedType.Name + "Id")
                .Configure(x => x.IsKey());

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(200));

            modelBuilder.Properties<DateTime>()
               .Configure(x => x.HasColumnType("DateTime2"));

            modelBuilder.Configurations.Add(new LibConfiguration());
            modelBuilder.Configurations.Add(new AutorConfiguration());
            modelBuilder.Configurations.Add(new EditoraConfiguration());

        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("DataCadastro") != null).ToList()
                .ForEach(x =>
                {
                    if (x.State == EntityState.Added)
                    {
                        x.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (x.State == EntityState.Added)
                    {
                        x.Property("DataCadastro").IsModified = false;
                    }
                });

            ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("Ativo") != null).ToList()
                .ForEach(x =>
                {

                    if (x.State == EntityState.Added)
                    {
                        x.Property("Ativo").CurrentValue = true;
                    }
                    if (x.State == EntityState.Deleted)
                    {
                        x.Property("Ativo").CurrentValue = false;
                    }
                });

            return base.SaveChanges();
        }
    }
}



