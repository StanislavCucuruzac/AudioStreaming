using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using AudioStreaming.API.Infrastructure.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            await host.SeedData();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
