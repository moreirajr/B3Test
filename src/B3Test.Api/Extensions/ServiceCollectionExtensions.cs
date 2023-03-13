using B3Test.Api.Middlewares;
using B3Test.Api.Swagger;
using B3Test.Domain.Repositories;
using B3Test.Infrastructure.Persistence.Extensions;
using B3Test.Infrastructure.Repositories;
using B3Test.MessageBus.MassTransit.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace B3Test.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string ApplicationAssemblyName = "B3Test.Application";
        private const string InfrastructureAssemblyName = "B3Test.Infrastructure";
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("Content-Disposition"));
            });
            services.ConfigureApiVersioning();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "B3Test.Api", Version = "v1" });
                c.SchemaFilter<EnumSchemaFilter>();
            });
            services.AddTransient<ExceptionHandlerMiddleware>();

            services.AddMediatorConfiguration();
            services.AddApplicationServices(configuration);
            services.AddMessageBusConfiguration(configuration);
        }

        private static void AddMediatorConfiguration(this IServiceCollection services)
        {
            var appAssembly = AppDomain.CurrentDomain.Load(ApplicationAssemblyName);
            var infraAssembly = AppDomain.CurrentDomain.Load(InfrastructureAssemblyName);

            services.AddMediatR(config =>
            {
                config.Lifetime = ServiceLifetime.Scoped;
                config.RegisterServicesFromAssemblies(appAssembly, infraAssembly);
            });
        }

        private static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureEF(configuration.GetSection("DatabaseConnectionString").Value);

            services.AddScoped<ITarefaRepository, TarefaRepository>();
        }

        private static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}
