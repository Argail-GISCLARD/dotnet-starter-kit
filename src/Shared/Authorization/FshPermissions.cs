using System.Collections.ObjectModel;

namespace FSH.Starter.Shared.Authorization;

public static class FshPermissions
{
    private static readonly FshPermission[] AllPermissions =
    [     
        //tenants
        new("View Tenants", FshActions.View, FshResources.Tenants, IsRoot: true),
        new("Create Tenants", FshActions.Create, FshResources.Tenants, IsRoot: true),
        new("Update Tenants", FshActions.Update, FshResources.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FshActions.UpgradeSubscription, FshResources.Tenants, IsRoot: true),

        //identity
        new("View Users", FshActions.View, FshResources.Users),
        new("Search Users", FshActions.Search, FshResources.Users),
        new("Create Users", FshActions.Create, FshResources.Users),
        new("Update Users", FshActions.Update, FshResources.Users),
        new("Delete Users", FshActions.Delete, FshResources.Users),
        new("Export Users", FshActions.Export, FshResources.Users),
        new("View UserRoles", FshActions.View, FshResources.UserRoles),
        new("Update UserRoles", FshActions.Update, FshResources.UserRoles),
        new("View Roles", FshActions.View, FshResources.Roles),
        new("Create Roles", FshActions.Create, FshResources.Roles),
        new("Update Roles", FshActions.Update, FshResources.Roles),
        new("Delete Roles", FshActions.Delete, FshResources.Roles),
        new("View RoleClaims", FshActions.View, FshResources.RoleClaims),
        new("Update RoleClaims", FshActions.Update, FshResources.RoleClaims),
        
        //products
        new("View Products", FshActions.View, FshResources.Products, IsBasic: true),
        new("Search Products", FshActions.Search, FshResources.Products, IsBasic: true),
        new("Create Products", FshActions.Create, FshResources.Products),
        new("Update Products", FshActions.Update, FshResources.Products),
        new("Delete Products", FshActions.Delete, FshResources.Products),
        new("Export Products", FshActions.Export, FshResources.Products),

        //brands
        new("View Brands", FshActions.View, FshResources.Brands, IsBasic: true),
        new("Search Brands", FshActions.Search, FshResources.Brands, IsBasic: true),
        new("Create Brands", FshActions.Create, FshResources.Brands),
        new("Update Brands", FshActions.Update, FshResources.Brands),
        new("Delete Brands", FshActions.Delete, FshResources.Brands),
        new("Export Brands", FshActions.Export, FshResources.Brands),

        //jacxsons
        new("View JacXson", FshActions.View, FshResources.JacXsons, IsBasic: true),
        new("Search JacXson", FshActions.Search, FshResources.JacXsons, IsBasic: true),
        new("Create JacXson", FshActions.Create, FshResources.JacXsons),
        new("Update JacXson", FshActions.Update, FshResources.JacXsons),
        new("Delete JacXson", FshActions.Delete, FshResources.JacXsons),
        new("Export JacXson", FshActions.Export, FshResources.JacXsons),

        //recipes
        new("View Recipes", FshActions.View, FshResources.Recipes, IsBasic: true),
        new("Search Recipes", FshActions.Search, FshResources.Recipes, IsBasic: true),
        new("Create Recipes", FshActions.Create, FshResources.Recipes),
        new("Update Recipes", FshActions.Update, FshResources.Recipes),
        new("Delete Recipes", FshActions.Delete, FshResources.Recipes),
        new("Export Recipes", FshActions.Export, FshResources.Recipes),

        //recipeversions
        new("View RecipeVersions", FshActions.View, FshResources.RecipeVersions, IsBasic: true),
        new("Search RecipeVersions", FshActions.Search, FshResources.RecipeVersions, IsBasic: true),
        new("Create RecipeVersions", FshActions.Create, FshResources.RecipeVersions),
        new("Update RecipeVersions", FshActions.Update, FshResources.RecipeVersions),
        new("Delete RecipeVersions", FshActions.Delete, FshResources.RecipeVersions),
        new("Export RecipeVersions", FshActions.Export, FshResources.RecipeVersions),

         new("View Hangfire", FshActions.View, FshResources.Hangfire),
         new("View Dashboard", FshActions.View, FshResources.Dashboard),

        //audit
        new("View Audit Trails", FshActions.View, FshResources.AuditTrails),
    ];

    public static IReadOnlyList<FshPermission> All { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions);
    public static IReadOnlyList<FshPermission> Root { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Admin { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Basic { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => p.IsBasic).ToArray());
}

public record FshPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource)
    {
        return $"Permissions.{resource}.{action}";
    }
}


