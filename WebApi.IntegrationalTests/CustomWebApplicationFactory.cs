using AudioStreaming.API;
using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Dal.Repository;
using AudioStreaming.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IntegrationalTests.Mock;

namespace WebApi.IntegrationalTests
{
    public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(IRepo<Artist>));

                services.Remove(descriptor);

                services.AddScoped<IRepo<Artist>, ArtistRepositoryMock>();
            });
        }
    }
}
