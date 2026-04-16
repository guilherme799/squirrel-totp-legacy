using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Squirrel.Autentication.Playground.Infrastructure
{
  public class DefaultDependencyResolver : IDependencyResolver
  {
    private readonly IServiceProvider serviceProvider;

    public DefaultDependencyResolver(IServiceProvider serviceProvider)
    {
      this.serviceProvider = serviceProvider;
    }

    public object GetService(Type serviceType)
      => serviceProvider.GetService(serviceType);
    public IEnumerable<object> GetServices(Type serviceType)
      => serviceProvider.GetServices(serviceType);

    public IDependencyScope BeginScope()
    {
      var scope = serviceProvider.CreateScope();
      return new DefaultDependencyScope(scope);
    }

    public void Dispose()
    { }
  }

  public class DefaultDependencyScope : IDependencyScope
  {
    private readonly IServiceScope _scope;

    public DefaultDependencyScope(IServiceScope scope) => _scope = scope;

    public object GetService(Type serviceType) => _scope.ServiceProvider.GetService(serviceType);

    public IEnumerable<object> GetServices(Type serviceType) => _scope.ServiceProvider.GetServices(serviceType);

    public void Dispose() => _scope.Dispose();
  }
}