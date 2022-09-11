static class GetAllPolicyRepository
{
  public static IEnumerable<GetPolicyDto> Get(SqlConnection connectionString, int? pageNumber, int? size)
  {
    return connectionString.Query<GetPolicyDto>("SELECT id_apolice, data_inicio, data_fim, premio, indenizacao, id_cobertura, id_usuario, id_cliente, id_veiculo, status from Apolices WHERE status != 'Rejeitada' ORDER BY id_apolice OFFSET @PageNumber ROWS FETCH NEXT @Size ROWS ONLY", new { PageNumber = (pageNumber - 1) * size, Size = size });
  }
}