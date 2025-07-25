using Microsoft.EntityFrameworkCore;
using DepoimentosApi.Models; // ou o namespace correto do seu model

namespace DepoimentosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Destinos> Destinos { get; set; }
    }
}
