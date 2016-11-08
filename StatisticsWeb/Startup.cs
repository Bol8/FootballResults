using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StatisticsWeb.Startup))]

namespace StatisticsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}