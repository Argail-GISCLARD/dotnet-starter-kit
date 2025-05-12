using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Constants;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence;

public sealed class CatalogDbContext : FshDbContext
{
    public CatalogDbContext(IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor, DbContextOptions<CatalogDbContext> options, IPublisher publisher, IOptions<DatabaseOptions> settings)
        : base(multiTenantContextAccessor, options, publisher, settings)
    {
    }
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<JacXson> JacXsons { get; set; } = null!;
    public DbSet<RecipeVersion> RecipeVersions { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<JacXsonEvent> JacXsonEvent { get; set; } = null!;
    public DbSet<JacXsonRecipeVersion> JacXsonRecipeVersions { get; set; } = null!;
    public DbSet<JacXsonType> JacXsonTypes { get; set; } = null!;
    public DbSet<PlaneEngine> PlaneEngines  { get; set; } = null!;
    public DbSet<PlaneModel> PlaneModels { get; set; } = null!;
    public DbSet<PlaneEngineConfiguration> PlaneEngineConfigurations { get; set; } = null!;
    public DbSet<PlaneManufacturer> PlaneManufacturers { get; set; } = null!;
    public DbSet<RecipeChangelog> RecipeChangelogs { get; set; } = null!;
    public DbSet<RecipeContent> RecipeContents { get; set; } = null!;
    public DbSet<RecipeStatus> RecipeStatuses { get; set; } = null!;
    public DbSet<RecipeTemplate> RecipeTemplates { get; set; } = null!;
    public DbSet<RecipeTemplateContent> RecipeTemplateContents { get; set; } = null!;
    public DbSet<Stand> Stands { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}
