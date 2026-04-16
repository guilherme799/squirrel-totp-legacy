using Microsoft.Extensions.DependencyInjection;
using Squirrel.Autentication.Totp.Domain.Services;
using Squirrel.Autentication.Totp.Services;

namespace Squirrel.Autentication.Totp.Infrastructure.IOC
{
  public static class DependencyInjection
  {
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
      services.AddScoped<ICodeService, CodeService>();

      return services;
    }
  }
}
