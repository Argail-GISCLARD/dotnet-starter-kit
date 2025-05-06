using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Create.v1;
public sealed record CreateJacXsonCommand(
    [property: DefaultValue("Sample JacXson")] string? SerialNumber,
    [property: DefaultValue(0)] int Status,
    [property: DefaultValue("w0")] string? W0 = null,
    [property: DefaultValue("L")] string? L = null,
    [property: DefaultValue("Salt")] string? Salt = null) : IRequest<CreateJacXsonResponse>;

