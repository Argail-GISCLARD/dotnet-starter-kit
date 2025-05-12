using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Create.v1;
public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
        RuleFor(rv => rv.TenantId).MaximumLength(64);
    }
}
