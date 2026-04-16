using System;
using QRCoder;

namespace Squirrel.Autentication.Playground.Domain.Models
{
  public class GetTotpConfigurationResponse
  {
    public Uri TotpUri { get; }
    public string SecretKey { get; }
    public string QrCode { get; }

    public GetTotpConfigurationResponse(string totpUri, string secretKey)
    {
      TotpUri = new Uri(totpUri);
      SecretKey = secretKey;
      QrCode = BuildQrCode(totpUri);
    }

    private string BuildQrCode(string totpUri)
    {
      using(var qrCodeGenerator = new QRCodeGenerator())
        using(var qrCodeData = qrCodeGenerator.CreateQrCode(totpUri, QRCodeGenerator.ECCLevel.Q))
        return new Base64QRCode(qrCodeData)
          .GetGraphic(5);
    }
  }
}