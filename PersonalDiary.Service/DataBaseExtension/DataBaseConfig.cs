using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalDiary.Data.Context;
using AutoMapper;
using System.Reflection;

namespace PersonalDiary.Service.DataBaseExtension
{
   public static class DataBaseConfig
    {
        public static void DatabaseConfig(this IServiceCollection services, IConfiguration _configuration)
        {
            var connection = _configuration.GetConnectionString("DBContext");
            services.AddDbContext<PersonalDiaryContext>(options => options.UseSqlServer(connection));
            services.AddScoped<DbContext, PersonalDiaryContext>();
        }
    }
}
