using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Update.v1;
public sealed record UpdateJacXsonCommand(
    Guid Id,
    string SerialNumber,
    int Status,
    string W0,
    string L,
    string Salt) : IRequest<UpdateJacXsonResponse>;
