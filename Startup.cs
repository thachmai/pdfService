using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileSystems;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Framework.DependencyInjection;

namespace HelloMvc
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();

            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddInstance<IHostingEnvironment>(new HostingEnvironment() { WebRoot = "wwwroot" });
            });

            app.UseStaticFiles();
            app.UseMvc();

            app.UseWelcomePage();
        }       
    }
}