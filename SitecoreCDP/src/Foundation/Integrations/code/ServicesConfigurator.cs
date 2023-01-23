using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using SitecoreCDP.Foundation.Integrations.Controllers;

namespace SitecoreCDP.Foundation.Integrations
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Transient(typeof(IdentifyGuestController), typeof(IdentifyGuestController)));
        }
    }
}