﻿using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class RecipeTemplateConfiguration : IEntityTypeConfiguration<RecipeTemplate>
{
    public void Configure(EntityTypeBuilder<RecipeTemplate> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
    }
}
