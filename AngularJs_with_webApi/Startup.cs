using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJs_with_webApi.Startup))]
namespace AngularJs_with_webApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
