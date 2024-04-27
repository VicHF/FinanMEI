using FinanMEI.Migrations;
using FinanMEI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FinanMEI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Despesa> Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .Property(p => p.NomeProduto)
                .HasConversion(
                    v => v.ToUpper(), // converte para caixa alta antes de salvar
                    v => v); // converte de volta para o valor original

            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.NomeProduto) // cria um índice exclusivo para NomeProduto
                .IsUnique();

            modelBuilder.Entity<Venda>()
                .HasIndex(p => new { p.NomeProduto, p.Data });

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Produto) // especifica a propriedade de navegação para a entidade relacionada
                .WithMany(p => p.Vendas) // especifica a propriedade de navegação inversa
                .HasForeignKey(v => v.IdProduto);
        }
    }
}
