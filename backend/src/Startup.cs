using System;
using System.Net;
using System.Net.Http;
using Core.Libs.Integration.GoogleMap;
using Core.Libs.Service;
using Hamilton.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Hamilton
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

            // Configuration api controller
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddMvcOptions(options =>
                {
                    options.EnableEndpointRouting = false;
                });

            // Config Server
            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()

                .AddOptions();

            services
                .AddSingleton(
                    new HttpClient(
                        new HttpClientHandler()
                        {
                            AllowAutoRedirect = false,
                            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                        })
                    {
                        Timeout = TimeSpan.FromSeconds(10)
                    });

            services.RegisterApiVersioning();

            services.RegisterSwagger(Configuration);

            services.RegisterIntegrationGoogleMap(Configuration);

             services
                .AddTransient<IHamiltonBusiness, HamiltonBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.RunSwagger(provider);
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
