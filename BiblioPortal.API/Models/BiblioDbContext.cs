using BiblioPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.API.Models

{
    public class BiblioDbContext : DbContext
    {
        public DbSet<Outil> Outils { get; set; }

        public BiblioDbContext(DbContextOptions<BiblioDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
