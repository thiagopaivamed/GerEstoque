using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Mapeamentos
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(m => m.MovimentacaoId);

            builder.Property(m => m.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(m => m.DataMovimentacao).IsRequired();

            builder.HasOne(m => m.Produto).WithMany(m => m.Movimentacoes).HasForeignKey(m => m.ProdutoId).IsRequired();

            builder.ToTable("Movimentacoes");
        }
    }
}