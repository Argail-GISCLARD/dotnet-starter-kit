using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class RecipeTemplateContentConfiguration : IEntityTypeConfiguration<RecipeTemplateContent>
{
    public void Configure(EntityTypeBuilder<RecipeTemplateContent> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
    }
}
