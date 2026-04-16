using System.Web;
using System.Web.Http;
using Squirrel.Autentication.Playground.Domain.Models;
using Squirrel.Autentication.Totp.Domain.Services;

namespace Squirrel.Autentication.Playground.Controllers
{
  public class TotpController : ApiController
  {
    private readonly ICodeService codeService;

    public TotpController(ICodeService codeService)
    {
      this.codeService = codeService;
    }

    [HttpGet]
    [Authorize]
    [Route("api/totp/configuration")]
    public GetTotpConfigurationResponse GetTotpConfiguration()
    {
      var currentUserName = HttpContext.Current.User.Identity.Name;
      var (uri, secretKey) = codeService.GenerateTotpConfiguration("Squirrel Inc", currentUserName);

      return new GetTotpConfigurationResponse(uri, secretKey);
    }
  }
}
