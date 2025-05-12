using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class StandConfiguration : IEntityTypeConfiguration<Stand>
{
    public void Configure(EntityTypeBuilder<Stand> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}
