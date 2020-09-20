using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using eClinic.PatientRegistration.AppService;
using eClinic.PatientRegistration.Domain;
using eClinic.PatientRegistration.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Identity.Web;

namespace eClinic.PatientRegistration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
                
            BuildDependency(services);

        services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd");

        // services.AddAuthentication(AzureADDefaults.JwtBearerAuthenticationScheme)
        //   .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            // services.AddMicrosoftIdentityWebAppAuthentication
            //     (Configuration, "AzureAd","OpenIdConnect","Cookies");

                    //.EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                    //.AddInMemoryTokenCaches();
            //   services.AddMi(AzureADDefaults.AuthenticationScheme)
            //     .AddAzureAD(options => config.Bind("AzureAd", options));
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(errorApp => {

                errorApp.Run(async context => {

                    var exceptionHandlerPathFeature = 
                        context.Features.Get<IExceptionHandlerPathFeature>();
                    
                   _logger.Error(exceptionHandlerPathFeature.Error); //log error stdout

                   context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An error occured at services");

                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void BuildDependency(IServiceCollection services)
        {
            var objMapper = new ObjectMapper();
            var mapper = objMapper.Mapper;

            services.AddSingleton<IMapper>(mapper);

            services.AddTransient<ISecretStore, SecretStore>();

            services.AddTransient
                <IPatientValidatorDomainService,PatientValidatorDomainService>();
            
            _logger = new ConsoleLogger();
            services.AddSingleton<IAppLogger>(_logger);

            services.AddTransient<IPatientAppService,PatientAppService>();

            services.AddTransient<IPatientRepository,PatientRepository>();
        }

        private IAppLogger _logger;
    }

    internal class AzureADDefaults
    {
    }
}
