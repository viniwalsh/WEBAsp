using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class PoderEntityConfiguration : IEntityTypeConfiguration<PoderEntity>
    {
        public void Configure(EntityTypeBuilder<PoderEntity> builder)
        {
            builder
                .HasOne(x => x.Heroi)
                .WithMany(x => x.Poderes);
        }
    }
}
