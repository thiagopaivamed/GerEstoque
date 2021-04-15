using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.Nome).HasMaxLength(30).IsRequired();

            builder.HasMany(c => c.Produtos).WithOne(c => c.Categoria);

            builder.ToTable("Categorias");
        }
    }
}