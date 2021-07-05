using AutoMapper;
using data.rarecarat.Context;
using data.rarecarat.Repository;
using domain.rarecarat.AutoMapper;
using domain.rarecarat.Business;
using domain.rarecarat.Contracts;
using domain.rarecarat.Contracts.Security;
using domain.rarecarat.Security;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using model.rarecarat.Demo.Validators;
using System;

namespace api.rarecarat
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddHealthChecks();

            services.AddCors( options =>
            {
                options.AddPolicy( "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader() );
            } );

            services.AddControllers()
                .AddFluentValidation( fv => fv.RegisterValidatorsFromAssemblyContaining<DiamondCreateValidator>() )
                .SetCompatibilityVersion( CompatibilityVersion.Latest )
                .AddJsonOptions( options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                } );
            ;

            #region [Mappers]

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration( mc =>
            {
                mc.AddProfile( new DiamondProfile() );
                mc.AddProfile( new ImageProfile() );
                mc.AddProfile( new RetailerProfile() );
            } );

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton<IMapper>( mapper );

            #endregion

            #region Injections
            // Auto Mapper Configurations
            services.AddAutoMapper( typeof( Startup ) );

            // Business
            services.AddTransient<IToken, Token>();
            services.AddTransient<IDiamondBusiness, DiamondBusiness>();

            // Repositories
            services.AddTransient<IDiamondRepository, DiamondRepository>();

            #endregion


            #region SQL

            services.AddDbContext<RarecaratContext>( options => options.UseInMemoryDatabase( databaseName: "RarecaratDB" )
                                                                       .UseQueryTrackingBehavior( QueryTrackingBehavior.NoTracking ) );
            #endregion

            services.AddSwaggerGen( c =>
            {
                 c.SwaggerDoc( "v1", new OpenApiInfo { Title = "api.rarecarat", Version = "v1" } );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory )
        {
            loggerFactory.AddFile( "logs/log-{Date}.txt" );

            app.UseHealthChecks( "/_healthz" );

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "api.rarecarat v1" ) );
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
