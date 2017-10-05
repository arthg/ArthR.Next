using ArthR.Next.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ArthR.Next
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
        }

        // intentionally breaking
        // if I ever get back to this - see:
        // https://weblogs.asp.net/ricardoperes/signalr-in-asp-net-core?WT.mc_id=DX_MVP4025064&utm_campaign=dotNET%20Weekly&utm_medium=email&utm_source=week__year_
        public void Config ure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("chat");
            });
        }
    }
}
