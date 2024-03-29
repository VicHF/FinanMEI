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
    }
}
