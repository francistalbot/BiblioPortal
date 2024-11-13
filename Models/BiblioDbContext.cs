﻿using Microsoft.EntityFrameworkCore;
namespace BiblioPortal.Models
{
    public class BiblioDbContext : DbContext
    {
        public DbSet<Outil> Outils { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public BiblioDbContext(DbContextOptions<BiblioDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
