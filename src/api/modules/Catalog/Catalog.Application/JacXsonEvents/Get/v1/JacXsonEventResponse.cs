namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
public sealed record JacXsonEventResponse(Guid? Id, string JacXsonSerialNumber, DateTime OccuredAt, string? Source, string? EventName, string? Details);
