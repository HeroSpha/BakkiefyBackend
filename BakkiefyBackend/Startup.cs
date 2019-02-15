using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BakkiefyBackend.Provider;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly:OwinStartup(typeof(BakkiefyBackend.Startup))]
namespace BakkiefyBackend
{
    
    public class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
            app.UseCors(CorsOptions.AllowAll);
            ConfigureOUath(app);
           // UnityConfig.RegisterComponents();

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true };
                hubConfiguration.EnableJSONP = true;
                map.RunSignalR(hubConfiguration);
            });
            HttpConfiguration config = new HttpConfiguration();
            app.UseWebApi(config);
            
        }
        public void ConfigureOUath(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthAuthorization = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(89999),
                Provider = new SimpleAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(oAuthAuthorization);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}