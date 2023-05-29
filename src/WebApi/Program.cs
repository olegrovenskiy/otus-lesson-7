using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Point1");
            
            await CreateHostBuilder(args).Build().RunAsync();

            Console.WriteLine("Point2");
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}