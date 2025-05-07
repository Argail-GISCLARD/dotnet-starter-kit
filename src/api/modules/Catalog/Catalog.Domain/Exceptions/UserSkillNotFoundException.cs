using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class UserSkillNotFoundException : NotFoundException
{
    public UserSkillNotFoundException(Guid id)
        : base($"user skill with id {id} not found")
    {
    }
}
