using AudioStreaming.Bll.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IntegrationalTest.Mock;

namespace WebApi.IntegrationalTest
{
    public class CustomWebApplicationFactory<TStartup>
         : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(IArtistService));

                services.Remove(descriptor);

                services.AddScoped<IArtistService, ArtistServiceMock>();
            });
        }
    }
}
