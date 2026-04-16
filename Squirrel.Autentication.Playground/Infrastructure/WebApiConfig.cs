using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;
using Squirrel.Autentication.Totp.Infrastructure.IOC;

namespace Squirrel.Autentication.Playground.Infrastructure
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      ConfigureApplicationJson(config);

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      var servicesProvider = new ServiceCollection()
        .RegisterServices()
        .RegisterControllers()
        .BuildServiceProvider();

      config.DependencyResolver = new DefaultDependencyResolver(servicesProvider);
    }

    private static void ConfigureApplicationJson(HttpConfiguration config)
    {
      config.Formatters.Remove(config.Formatters.XmlFormatter);

      var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;

      jsonSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
      jsonSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
    }
  }
}