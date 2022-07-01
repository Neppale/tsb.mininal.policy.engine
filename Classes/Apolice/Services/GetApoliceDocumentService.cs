static class GetApoliceDocumentService
{
  public static IResult Get(int id, string dbConnectionString)
  {
    SqlConnection connectionString = new SqlConnection(dbConnectionString);

    // Verificando se a apólice existe.
    bool apoliceExists = connectionString.QueryFirstOrDefault<bool>("SELECT id_apolice FROM Apolices WHERE id_apolice = @Id", new { Id = id });
    if (!apoliceExists) return Results.NotFound("Apólice não encontrada.");

    try
    {
      string data = connectionString.QueryFirstOrDefault<string>("SELECT documento FROM Apolices WHERE id_apolice = @Id", new { Id = id });
      string filePath = DocumentConverter.Decode(data, "application/pdf");

      //TODO: Results.File não encontra arquivos que não estão com root path.
      return Results.File(path: filePath, contentType: "application/pdf");

    }
    catch (SystemException)
    {
      return Results.BadRequest("Requisição feita incorretamente. Confira todos os campos e tente novamente. ");
    }



  }
}