using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class RecipeVersionConfiguration : IEntityTypeConfiguration<RecipeVersion>
{
    public void Configure(EntityTypeBuilder<RecipeVersion> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
    }
}
