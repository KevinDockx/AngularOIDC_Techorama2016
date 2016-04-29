using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Services.InMemory;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TripCompany.IdentityServer.Config;

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                var corsPolicyService = new DefaultCorsPolicyService()
                {
                    AllowAll = true
                };
                      
                var idServerServiceFactory = new IdentityServerServiceFactory()
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get())
                                .UseInMemoryUsers(Users.Get());

                idServerServiceFactory.CorsPolicyService = new
                    Registration<IdentityServer3.Core.Services.ICorsPolicyService>(corsPolicyService);

                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "TripCompany Security Token Service",
                    SigningCertificate = LoadCertificate(),
                    IssuerUri = "https://tripcompanysts/identity",
                    PublicOrigin = "https://localhost:44317"
                };
                idsrvApp.UseIdentityServer(options);
            });
        }


        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
