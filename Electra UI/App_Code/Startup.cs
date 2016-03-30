using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Electra_UI.Startup))]
namespace Electra_UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
