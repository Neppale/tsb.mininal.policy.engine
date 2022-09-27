public static class GetAllCoverageService
{
  /** <summary> Esta função retorna todas as coberturas no banco de dados. </summary>**/
  public static async Task<IResult> Get(SqlConnection connectionString, int? pageNumber, int? size)
  {
    if (pageNumber == null) pageNumber = 1;
    if (size == null) size = 5;

    var coverages = await GetAllCoverageRepository.Get(connectionString: connectionString, pageNumber: pageNumber, size: size);
    return Results.Ok(coverages);
  }
}
