using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FlightPath.Application.Aircrafts.Commands;
using FlightPath.Application.Airports.Commands;
using FlightPath.Application.Infrastructure;
using FlightPath.Application.Infrastructure.AutoMapper;
using FlightPath.Application.Interfaces;
using FlightPath.Application.Aircrafts.Queries;
using FlightPath.Application.Airports.Queries;
using FlightPath.Application.Route.Queries;
using FlightPath.Common;
using FlightPath.Infrastructure;
using FlightPath.Persistence;
using FlightPath.Api.Filters;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Swashbuckle.AspNetCore.Swagger;

namespace FlightPath.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;
        public Startup(IHostingEnvironment env, IConfiguration config,
        ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                // Development service configuration
                logger.LogInformation("Development environment");
            }
            else
            {
                // Non-development service configuration
                logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
 
            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR(typeof(GetAircraftDetailQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAircraftsListQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAirportDetailQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAirportsListQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAirportDtosListQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IFlightPathDbContext, FlightPathDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("FlightPathDatabase")));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation();

            services.AddTransient<IValidator<CreateAircraftCommand>, CreateAircraftCommandValidator>();
            services.AddTransient<IValidator<DeleteAircraftCommand>, DeleteAircraftCommandValidator>();
            services.AddTransient<IValidator<UpdateAircraftCommand>, UpdateAircraftCommandValidator>();
            services.AddTransient<IValidator<GetAircraftDetailQuery>, GetAircraftDetailQueryValidator>();
            services.AddTransient<IValidator<CreateAirportCommand>, CreateAirportCommandValidator>();
            services.AddTransient<IValidator<DeleteAirportCommand>, DeleteAirportCommandValidator>();
            services.AddTransient<IValidator<UpdateAirportCommand>, UpdateAirportCommandValidator>();
            services.AddTransient<IValidator<GetAirportDetailQuery>, GetAirportDetailQueryValidator>();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Flight Path API", Version = "v1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Path API V1.0");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
