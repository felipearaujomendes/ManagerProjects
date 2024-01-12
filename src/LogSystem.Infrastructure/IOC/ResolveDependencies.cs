using LogSystem.Application.Application;
using LogSystem.Domain.Configs;
using LogSystem.Domain.Repository;
using LogSystem.Infrastructure.Swagger;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace LogSystem.Infrastructure.IOC
{
    [ExcludeFromCodeCoverage]
    public static class ResolveDependencies
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {

            services.SwaggerAdd();

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddScoped<IDapperContext, DapperContext>();

            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IProjetosApplication, ProjetoApplication>();
            services.AddScoped<ITarefasApplication, TarefasApplication>();
            services.AddScoped<IComentariosApplication, ComentariosApplication>();


            services.AddSingleton<IConfiguration>(configuration);

            var assembly = AppDomain.CurrentDomain.Load("LogSystem.Application");
            services.AddMediatR(assembly);

            return services;
        }
        public static IApplicationBuilder Register(this IApplicationBuilder app)
        {
            app.SwaggerAdd();
            return app;
        }
    }
}
