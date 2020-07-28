using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(freelancerPlatform.Startup))]
namespace freelancerPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
