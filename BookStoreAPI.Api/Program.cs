using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStoreAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // entry point to application 
            // host creation in try, catch to catch all errors
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }  

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // declaring startup to use
                    webBuilder.UseStartup<Startup>();
                    // declaring port to use by server
                    webBuilder.UseKestrel(o => o.ListenLocalhost(8000));
                }).ConfigureAppConfiguration((hostContext, config) =>
                {
                    // adding external json configuration
                    config.AddJsonFile("appsettings.json", false);
                });
        }
    }
}
