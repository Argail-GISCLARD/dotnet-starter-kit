using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Create.v1;
public class CreateRecipeContentCommandValidator : AbstractValidator<CreateRecipeContentCommand>
{
    public CreateRecipeContentCommandValidator()
    {
    }
}
