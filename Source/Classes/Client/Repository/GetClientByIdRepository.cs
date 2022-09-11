static class GetClientByIdRepository
{
  /** <summary> Esta função retorna um cliente em específico no banco de dados. </summary>**/
  public static GetClientDto Get(int id, SqlConnection connectionString)
  {
    return connectionString.QueryFirstOrDefault<GetClientDto>("SELECT id_cliente, nome_completo, email, cpf, cnh, cep, data_nascimento, telefone1, telefone2 FROM Clientes WHERE id_cliente = @Id AND status = 'true'", new { Id = id });
  }
}