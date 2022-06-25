static class LoginClienteService
{
  /** <summary> Esta função faz o login do cliente. </summary>**/
  public static IResult Login(string email, string password, string dbConnectionString, WebApplicationBuilder builder)
  {
    SqlConnection connectionString = new SqlConnection(dbConnectionString);
    try
    {
      string hashPassword = connectionString.QueryFirstOrDefault<string>("SELECT senha FROM Clientes WHERE email = @Email", new { Email = email });

      if (hashPassword == null) return Results.BadRequest("E-mail ou senha inválidos.");

      // Verificando senha do cliente.
      bool isValid = PasswordHasher.Verify(hashPassword, password);
      if (!isValid) return Results.BadRequest("E-mail ou senha inválidos.");

      // Gerando token.
      var issuer = builder.Configuration["Jwt:Issuer"];
      var audience = builder.Configuration["Jwt:Audience"];
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(issuer: issuer, audience: audience, signingCredentials: credentials);

      var tokenHandler = new JwtSecurityTokenHandler();
      var stringToken = tokenHandler.WriteToken(token);

      return Results.Ok(stringToken);

    }
    catch (SystemException)
    {
      return Results.BadRequest("Requisição feita incorretamente. Confira todos os campos e tente novamente.");
    }
  }
}