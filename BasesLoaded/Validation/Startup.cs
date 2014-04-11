using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Validation.Startup))]
namespace Validation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
