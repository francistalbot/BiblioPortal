using BiblioPortal.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.API.Models

{
    public class BiblioDbContext : IdentityDbContext
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
