using AudioStreaming.API.Infrastructure.Extensions;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Bll.Profiles;
using AudioStreaming.Bll.Services;
using AudioStreaming.Dal;
using AudioStreaming.Dal.DataAcces;
using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Dal.Repository;
using AudioStreaming.Domain;
using AudioStreaming.Domain.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            InitializeLocalStorage(false);

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public string LocalStoragePath { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccess(LocalStoragePath);

            services.AddDbContext<AudioStreamingDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(@"Data Source =Stas; Initial Catalog = AudioStreamDb;
                Integrated Security = true");
                optionBuilder.UseSqlServer(x => x.MigrationsAssembly("AudioStreaming.Dal"));
            });
           
            services.AddAutoMapper(typeof(SongProfile));
            services.AddAutoMapper(typeof(ArtistProfile));
            services.AddAutoMapper(typeof(PlaylistProfile));

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
        private void InitializeLocalStorage(bool autoClear = true)
        {
            LocalStoragePath = Environment.ContentRootPath + "\\LocalStorage";

            if (autoClear && Directory.Exists(LocalStoragePath))
                Directory.Delete(LocalStoragePath, true);

            Directory.CreateDirectory(LocalStoragePath);
        }
    }
}
