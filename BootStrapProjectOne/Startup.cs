using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootStrapProjectOne.Startup))]
namespace BootStrapProjectOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
