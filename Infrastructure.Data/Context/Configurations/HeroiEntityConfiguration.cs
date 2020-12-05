using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class HeroiEntityConfiguration : IEntityTypeConfiguration<HeroiEntity>
    {
        public void Configure(EntityTypeBuilder<HeroiEntity> builder)
        {
            builder
                .HasMany(x => x.Poderes)
                .WithOne(x => x.Heroi);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(100);
        }
    }
}
