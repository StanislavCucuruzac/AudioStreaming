using AudioStreaming.API.Infrastructure.Extensions;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Bll.Profiles;
using AudioStreaming.Bll.Services;
using AudioStreaming.Dal;
using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Dal.Repository;
using AudioStreaming.Domain.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var contection = @"Data Source = DELL-PC\SQLEXPRESS; Initial Catalog = AudioStreaming;
            //    Integrated Security = SSPI";
            services.AddDbContext<AudioStreamingDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(@"Data Source = DELL-PC\SQLEXPRESS; Initial Catalog = AudioStreamDb;
                Integrated Security = SSPI");
                optionBuilder.UseSqlServer(x => x.MigrationsAssembly("AudioStreaming.Dal"));
            });

            //services.AddDbContext<AudioStreamingDbContext>(option => option.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("AudioStreaming.Dal")));


            services.AddAutoMapper(typeof(SongProfile));
            services.AddAutoMapper(typeof(ArtistProfile));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<AudioStreamingDbContext>();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwAuthentication(authOptions);
            services.AddControllers();

            services.AddScoped<IRepository, EfCoreRepository>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IArtistService, ArtistService>();
           // services.AddAutoMapper(typeof(BllAssemblyMarker));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AudioStreaming.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AudioStreaming.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
