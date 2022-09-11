static class GetAllUserService
{
  /** <summary> Esta função retorna todos os usuários no banco de dados. </summary>**/
  public static IResult Get(SqlConnection connectionString, int? pageNumber, int? size)
  {
    if (pageNumber == null) pageNumber = 1;
    if (size == null) size = 5;

    var data = GetAllUserRepository.Get(connectionString: connectionString, pageNumber: pageNumber, size: size);
    return Results.Ok(data);
  }
}