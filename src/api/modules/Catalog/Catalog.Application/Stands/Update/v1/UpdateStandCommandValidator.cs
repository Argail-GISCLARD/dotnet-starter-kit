using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Update.v1;
public class UpdateStandCommandValidator : AbstractValidator<UpdateStandCommand>
{
    public UpdateStandCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
