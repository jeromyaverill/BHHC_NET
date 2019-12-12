using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BHHC_NET.Startup))]
namespace BHHC_NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
