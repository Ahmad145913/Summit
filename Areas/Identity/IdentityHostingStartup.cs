using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SummitSchool.Areas.Identity.IdentityHostingStartup))]
namespace SummitSchool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

            });
        }
    }
}