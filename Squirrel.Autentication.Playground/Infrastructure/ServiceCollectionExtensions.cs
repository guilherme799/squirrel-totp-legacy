using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Squirrel.Autentication.Playground.Infrastructure
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection RegisterControllers(this IServiceCollection services)
    {
      var controllers = typeof(Global).Assembly.GetExportedTypes()
        .Where(t => !t.IsAbstract && !t.IsInterface && !t.IsGenericTypeDefinition)
        .Where(t => typeof(IHttpController).IsAssignableFrom(t) || t.Name.EndsWith("Controller"));

      foreach (var controller in controllers)
        services.AddTransient(controller);

      return services;
    }
  }
}