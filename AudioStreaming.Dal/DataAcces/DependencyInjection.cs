using AudioStreaming.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.DataAcces
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string localStoragePath)
        {
            services.AddScoped<IFileManager, LocalFileManager>(conf => new LocalFileManager(localStoragePath));

            return services;
        }
    }
}
