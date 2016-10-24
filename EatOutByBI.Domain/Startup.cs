using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EatOutByBI.Domain.Startup))]
namespace EatOutByBI.Domain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
