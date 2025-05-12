using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Create.v1;
public class CreateStandCommandValidator : AbstractValidator<CreateStandCommand>
{
    public CreateStandCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
