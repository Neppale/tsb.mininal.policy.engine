public abstract class VeiculoController
{
  public static void ActivateEndpoints(WebApplication app, string dbConnectionString)
  {
    app.MapGet("/veiculo/", () =>
    {
      return GetAllVeiculoService.Get(dbConnectionString: dbConnectionString);

    })
    .WithName("Selecionar todos os veículos");

    app.MapGet("/veiculo/{id:int}", (int id) =>
    {
      return GetOneVeiculoService.Get(id: id, dbConnectionString: dbConnectionString);
    })
    .WithName("Selecionar veículo específico");

    app.MapPost("/veiculo/", (Veiculo veiculo) =>
    {
      return InsertVeiculoService.Insert(veiculo: veiculo, dbConnectionString: dbConnectionString);

    })
    .WithName("Inserir veículo");

    app.MapPut("/veiculo/{id:int}", (int id, Veiculo veiculo) =>
    {
      return UpdateVeiculoService.Update(id: id, veiculo: veiculo, dbConnectionString: dbConnectionString);
    })
    .WithName("Alterar veículo específico");

    app.MapDelete("/veiculo/{id:int}", (int id) =>
    {
      return DeleteVeiculoService.Delete(id: id, dbConnectionString: dbConnectionString);
    })
    .WithName("Deletar veículo específico");
  }
}
