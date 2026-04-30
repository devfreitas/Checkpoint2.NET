using Microsoft.EntityFrameworkCore;
using CP2.Models;

namespace CP2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; }
    }
}