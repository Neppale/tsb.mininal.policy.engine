static class UpdateVehicleRepository
{
  public static Veiculo? Update(int id, Veiculo veiculo, SqlConnection connectionString)
  {
    try
    {
      connectionString.Query("UPDATE Veiculos SET marca = @Marca, modelo = @Modelo, ano = @Ano, uso = @Uso, placa = @Placa, renavam = @Renavam, sinistrado = @Sinistrado, id_cliente = @IdCliente WHERE id_Veiculo = @Id", new { Marca = veiculo.marca, Modelo = veiculo.modelo, Ano = veiculo.ano, Uso = veiculo.uso, Placa = veiculo.placa, Renavam = veiculo.renavam, Sinistrado = veiculo.sinistrado, IdCliente = veiculo.id_cliente, Id = id });

      var updatedVehicle = connectionString.QueryFirstOrDefault<Veiculo>("SELECT * FROM Veiculos WHERE id_Veiculo = @Id", new { Id = id });
      return updatedVehicle;
    }
    catch (SystemException)
    {
      return null;
    }
  }
}