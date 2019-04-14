using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Inf.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Console.WriteLine("Unobserved exception: {0}", e.Exception);
            };

            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
                .Build();
        
    }
}
