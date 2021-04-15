using Models;
using Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new MovimentacaoMap());
            builder.ApplyConfiguration(new CategoriaMap());
        }
        
        
    }
}