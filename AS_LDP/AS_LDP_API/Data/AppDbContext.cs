using Microsoft.EntityFrameworkCore;
using GerenciamentoAPI.Models;

namespace GerenciamentoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
