namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
public sealed record JacXsonResponse(Guid? Id, string SerialNumber, int Status, string W0, string L, string Salt);
