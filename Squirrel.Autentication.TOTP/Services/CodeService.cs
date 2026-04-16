using OtpNet;

namespace Squirrel.Autentication.Totp.Services
{
  internal class CodeService : Domain.Services.ICodeService
  {
    public (string uri, string secretKey) GenerateTotpConfiguration(string issuer, string accountName)
    {
      var secretKey = KeyGeneration.GenerateRandomKey(20);
      var otpUri = new OtpUri(OtpType.Totp, secretKey, accountName, issuer);

      return (otpUri.ToString(), otpUri.Secret);
    }

    public bool Validate(string code, string secretKey)
    {
      var secret = Base32Encoding.ToBytes(secretKey);
      var totp = new OtpNet.Totp(secret);

      return totp.VerifyTotp(code, out _, VerificationWindow.RfcSpecifiedNetworkDelay);
    }
  }
}
