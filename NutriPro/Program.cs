using NutriPro.Models;

namespace NutriPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middleware para redirecionar apenas URLs de /Chat para HTTPS
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/Chat") && !context.Request.IsHttps)
                {
                    // Construir a URL HTTPS para redirecionar
                    var httpsUrl = $"https://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                    context.Response.Redirect(httpsUrl, permanent: true);
                    return;
                }

                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Configuração das rotas
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
