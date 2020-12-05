using Domain.Model.Models;
using Infrastructure.Data.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PoderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HeroiEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HeroiEntity> Herois { get; set; }

        public DbSet<PoderEntity> Poderes { get; set; }
    }
}
