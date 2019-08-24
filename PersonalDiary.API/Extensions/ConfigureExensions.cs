using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalDiary.API.Extensions
{
    /// <inheritdoc />
    public static class ConfigureExensions
    {
        /// <inheritdoc />
        public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            app.CorsConfig();
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseHsts();
            app.UseHttpsRedirection();
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotifyHub>("/notify");
            });
            app.UseMvc();
            app.SwaggerConfig(configuration);
            return app;
        }
        private static void CorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
        private static void SwaggerConfig(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string endPoint = configuration["SwaggerConfig:EndPoint"];
                string title = configuration["SwaggerConfig:Title"];
                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
