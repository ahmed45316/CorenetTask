using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using PersonalDiary.Service.DataBaseExtension;
using PersonalDiary.Service.Interfaces;
using PersonalDiary.Service.Services;
using System.Reflection;
using PersonalDiary.Service.AutoMapperConfig;
using AutoMapper;
using PersonalDiary.Data.UnitOfWork;

namespace PersonalDiary.API.Extensions
{
    /// <inheritdoc />
    public static class ServicesExtensions
    {
        /// <inheritdoc />
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperConfig)));
            services.AddApiDocumentationServices(configuration);
            services.DatabaseConfig(configuration);
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient<IPersonalDiaryServices, PersonalDiaryServices>();
            services.AddTransient<IImageServices, ImageServices>();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services;
        }
        private static void AddApiDocumentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                string title = configuration["SwaggerConfig:Title"];
                string version = configuration["SwaggerConfig:Version"];
                string docPath = configuration["SwaggerConfig:DocPath"];
                options.SwaggerDoc(version, new Info { Title = title, Version = version });
                options.DescribeAllEnumsAsStrings();
                var filePath = Path.Combine(AppContext.BaseDirectory, docPath);
                options.IncludeXmlComments(filePath);
            });
        }
    }
}
