namespace Squirrel.Autentication.Totp.Domain.Services
{
  public interface ICodeService
  {
    /// <summary>
    /// Retorna a URI e a chave secreta necessários para configurar um aplicativo de autenticação
    /// </summary>
    /// <param name="issuer">Aplicação externa à qual o usuário será associado no aplicatico de autenticação</param>
    /// <param name="accountName">O nome do usuário da aplicação externa que será cadastrado no aplicatico de autenticação. <code>Exemplo: john.doe@email.com/John Doe/John%20Doe</code></param>
    /// <returns><b>URI:</b>Utilizada para cadastrar, via QRCode, o novo código no aplicativo de autenticação</returns>
    (string uri, string secretKey) GenerateTotpConfiguration(string issuer, string accountName);


    /// <summary>
    /// Valida o código de 6 digítos gerado pelo aplicativo de atenticação com base na chave secreta do usuário
    /// </summary>
    /// <param name="code">Código de 6 digítos gerado pela aplicação de autenticação do usuário</param>
    /// <param name="secretKey">Chave secreta do usuário utilizada para gerar o código de 6 digítos</param>
    /// <returns>Resultado da validação do código com base na chave secreta</returns>
    bool Validate(string code, string secretKey);
  }
}
