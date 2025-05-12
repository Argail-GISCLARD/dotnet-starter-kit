using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Update.v1;
public class UpdateRecipeTemplateContentCommandValidator : AbstractValidator<UpdateRecipeTemplateContentCommand>
{
    public UpdateRecipeTemplateContentCommandValidator()
    {
    }
}
