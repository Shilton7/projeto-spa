using Microsoft.EntityFrameworkCore;
using servico_aula_api.Models;

namespace servico_aula_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
