using System;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using Squirrel.Autentication.Playground.Domain.Models;
using Squirrel.Autentication.Playground.Infrastructure;

namespace Squirrel.Autentication.Playground
{
  public class Global : HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
    }

    protected void Session_Start(object sender, EventArgs e)
    {

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
      var application = (sender as HttpApplication);
      var authorizationHeader = application.Request.Headers[HttpRequestHeader.Authorization.ToString()];

      if (authorizationHeader != null)
      {
        var authorization = Convert.FromBase64String(authorizationHeader.Replace("Basic ", string.Empty));
        var userName = Encoding.UTF8.GetString(authorization).Split(':')[0];

        application.Context.User = new SquirrelPrincipal(userName);
      }
    }

    protected void Application_Error(object sender, EventArgs e)
    {

    }

    protected void Session_End(object sender, EventArgs e)
    {

    }

    protected void Application_End(object sender, EventArgs e)
    {
    }
  }
}