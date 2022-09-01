static class GetAllIncidentRepository
{
  public static IEnumerable<GetAllIncidentsDto> Get(SqlConnection connectionString, int? pageNumber, int? size)
  {
    return connectionString.Query<GetAllIncidentsDto>("SELECT id_ocorrencia, Clientes.nome_completo AS nome, tipo, data, Ocorrencias.status FROM Ocorrencias LEFT JOIN Clientes ON Clientes.id_cliente = Ocorrencias.id_cliente ORDER BY id_ocorrencia OFFSET @PageNumber ROWS FETCH NEXT @Size ROWS ONLY", new { PageNumber = (pageNumber - 1) * size, Size = size });
  }
}