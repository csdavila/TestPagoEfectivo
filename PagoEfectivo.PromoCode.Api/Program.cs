using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace PagoEfectivo.PromoCode.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string localPath = AppDomain.CurrentDomain.BaseDirectory;
            string logFile = Path.Combine(localPath, "Log", "PagoEfectivo.PromoCode.Log.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(logFile)
                .CreateLogger();
            try
            {
                Log.Information("Iniciando la aplicación...");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ocurrió un problema al iniciar la aplicación.");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
