using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        /*
         * TODO 6: Fix issue
         * Users complains that sometimes, when they call AccountController.UpdateAccount followed by
         * AccountController.GetByInternalId they get account with counter equals 0, like if UpdateCounter was never
         * called.
         * It looks like as if there were two accounts, one being updated by UpdateAccount method and another does not.
         * Find out the problem and fix it.
         */
    }
}