﻿using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class PlaneManufacturerConfiguration : IEntityTypeConfiguration<PlaneManufacturer>
{
    public void Configure(EntityTypeBuilder<PlaneManufacturer> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}
