using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // creates database on start, if it doesn't exist
            using(var scope= host.Services.CreateScope()){
                var services = scope.ServiceProvider;
                var loggerFactory= services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context= services.GetRequiredService<MovieContext>();
                    await context.Database.MigrateAsync();
                }
                catch(Exception ex)
                {
                    var logger= loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error has occured during migration.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
