using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.PostgreSQL.Catalog
{
    /// <inheritdoc />
    public partial class AddedRecipeOperationCollectionTorecipeVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeOperations_RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations",
                column: "RecipeVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeOperations_RecipeVersions_RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations",
                column: "RecipeVersionId",
                principalSchema: "catalog",
                principalTable: "RecipeVersions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeOperations_RecipeVersions_RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations");

            migrationBuilder.DropIndex(
                name: "IX_RecipeOperations_RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations");

            migrationBuilder.DropColumn(
                name: "RecipeVersionId",
                schema: "catalog",
                table: "RecipeOperations");
        }
    }
}
