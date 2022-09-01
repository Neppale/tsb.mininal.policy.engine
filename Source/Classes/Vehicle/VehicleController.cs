public static class VehicleController
{
  public static void ActivateEndpoints(WebApplication app, SqlConnection connectionString)
  {
    app.MapGet("/veiculo/", [Authorize] (int? pageNumber, int? size) =>
    {
      return GetAllVehicleService.Get(connectionString: connectionString, pageNumber: pageNumber, size: size);
    })
    .WithName("Selecionar todos os veículos");

    app.MapGet("/veiculo/{id:int}", [Authorize] (int id) =>
    {
      return GetVehicleByIdService.Get(id: id, connectionString: connectionString);
    })
    .WithName("Selecionar veículo específico");

    app.MapGet("/veiculo/cliente/{id:int}", [Authorize] (int id, int? pageNumber, int? size) =>
    {
      return GetVehiclesByClientService.Get(id_cliente: id, pageNumber: pageNumber, connectionString: connectionString, size: size);
    })
    .WithName("Selecionar veículo por cliente");

    app.MapPost("/veiculo/", [Authorize] (Veiculo veiculo) =>
    {
      return InsertVehicleService.Insert(vehicle: veiculo, connectionString: connectionString);
    })
    .WithName("Inserir veículo");

    app.MapPut("/veiculo/{id:int}", [Authorize] (int id, Veiculo veiculo) =>
    {
      return UpdateVehicleService.Update(id: id, vehicle: veiculo, connectionString: connectionString);
    })
    .WithName("Alterar veículo específico");

    app.MapDelete("/veiculo/{id:int}", [Authorize] (int id) =>
    {
      return DeleteVehicleService.Delete(id: id, connectionString: connectionString);
    })
    .WithName("Deletar veículo específico");

  }
}
