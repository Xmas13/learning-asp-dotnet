using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace ContosoCrafts.Website
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<JsonFileProductService>();
            builder.Services.AddControllers();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapBlazorHub();

            app.MapRazorPages();
            // A way to create a web API, but not the best way to do it.
            //app.MapGet("/products", (context) =>
            //{
            //    var products = app.Services.GetService<JsonFileProductService>().GetProducts();
            //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
            //    context.Response.ContentType = "application/json";
            //    return context.Response.WriteAsync(json);
            //});
            app.Run();
        }
    }
}