using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EatOutByBI1.Startup))]
namespace EatOutByBI1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
