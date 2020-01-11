using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://0.0.0.0:5000;https://0.0.0.0:5001")
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
    }
}