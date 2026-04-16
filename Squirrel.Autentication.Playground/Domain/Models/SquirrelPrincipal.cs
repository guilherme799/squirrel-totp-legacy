using System;
using System.Security.Principal;

namespace Squirrel.Autentication.Playground.Domain.Models
{
  public class SquirrelPrincipal : IPrincipal
  {
    public IIdentity Identity { get; }

    public SquirrelPrincipal(string name)
    {
      Identity = new SquirrelIdentity(name);
    }

    public bool IsInRole(string role)
    {
      throw new NotImplementedException();
    }
  }

  public class SquirrelIdentity : IIdentity
  {
    public string Name { get; }

    public string AuthenticationType { get; }

    public bool IsAuthenticated { get => !string.IsNullOrWhiteSpace(Name); }

    public SquirrelIdentity(string name)
    {
      Name = name;
      AuthenticationType = System.Net.AuthenticationSchemes.Basic.ToString();
    }
  }
}