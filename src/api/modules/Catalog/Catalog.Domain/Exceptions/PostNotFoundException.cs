using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class PostNotFoundException : NotFoundException
{
    public PostNotFoundException(Guid id)
        : base($"post with id {id} not found")
    {
    }
}
