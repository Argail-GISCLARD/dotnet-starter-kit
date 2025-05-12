using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
using FSH.Starter.WebApi.Catalog.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Infrastructure;
public static class CatalogModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("catalog") { }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var recipeGroup = app.MapGroup("recipes").WithTags("recipes");
            recipeGroup.MapRecipeCreationEndpoint();
            recipeGroup.MapGetRecipeEndpoint();
            recipeGroup.MapGetRecipeListEndpoint();
            recipeGroup.MapRecipeUpdateEndpoint();
            recipeGroup.MapRecipeDeleteEndpoint();

            var jacXsonGroup = app.MapGroup("jacXsons").WithTags("jacXsons");
            jacXsonGroup.MapJacXsonCreationEndpoint();
            jacXsonGroup.MapGetJacXsonEndpoint();
            jacXsonGroup.MapGetJacXsonListEndpoint();
            jacXsonGroup.MapJacXsonUpdateEndpoint();
            jacXsonGroup.MapJacXsonDeleteEndpoint();

            var recipeVersionGroup = app.MapGroup("recipeversions").WithTags("recipeversions");
            recipeVersionGroup.MapRecipeVersionCreationEndpoint();
            recipeVersionGroup.MapGetRecipeVersionEndpoint();
            recipeVersionGroup.MapGetRecipeVersionListEndpoint();
            recipeVersionGroup.MapRecipeVersionUpdateEndpoint();
            recipeVersionGroup.MapRecipeVersionDeleteEndpoint();

            var operationGroup = app.MapGroup("operations").WithTags("operations");
            operationGroup.MapOperationCreationEndpoint();
            operationGroup.MapGetOperationEndpoint();
            operationGroup.MapGetOperationListEndpoint();
            operationGroup.MapOperationUpdateEndpoint();
            operationGroup.MapOperationDeleteEndpoint();
        }
    }
    public static WebApplicationBuilder RegisterCatalogServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<CatalogDbContext>();
        builder.Services.AddScoped<IDbInitializer, CatalogDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<Recipe>, CatalogRepository<Recipe>>("catalog:recipes");
        builder.Services.AddKeyedScoped<IReadRepository<Recipe>, CatalogRepository<Recipe>>("catalog:recipes");
        builder.Services.AddKeyedScoped<IRepository<JacXson>, CatalogRepository<JacXson>>("catalog:jacxsons");
        builder.Services.AddKeyedScoped<IReadRepository<JacXson>, CatalogRepository<JacXson>>("catalog:jacxsons");
        builder.Services.AddKeyedScoped<IRepository<RecipeVersion>, CatalogRepository<RecipeVersion>>("catalog:recipeversions");
        builder.Services.AddKeyedScoped<IReadRepository<RecipeVersion>, CatalogRepository<RecipeVersion>>("catalog:recipeversions");
        builder.Services.AddKeyedScoped<IRepository<Operation>, CatalogRepository<Operation>>("catalog:operations");
        builder.Services.AddKeyedScoped<IReadRepository<Operation>, CatalogRepository<Operation>>("catalog:operations");
        return builder;
    }
    public static WebApplication UseCatalogModule(this WebApplication app)
    {
        return app;
    }
}
