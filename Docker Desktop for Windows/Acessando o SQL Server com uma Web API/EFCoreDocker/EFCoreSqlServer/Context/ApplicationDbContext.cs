using EFCoreSqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSqlServer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();  //se não existir cria o Banco
        }

        public DbSet<Product> Products { get; set; }
    }
}
