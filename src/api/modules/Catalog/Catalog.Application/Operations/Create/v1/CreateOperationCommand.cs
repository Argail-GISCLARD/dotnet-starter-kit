using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Create.v1;
public sealed record CreateOperationCommand(
    [property: DefaultValue("Sample Operation")] string? Name) : IRequest<CreateOperationResponse>;
