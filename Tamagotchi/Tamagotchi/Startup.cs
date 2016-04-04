using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamagotchi.Startup))]
namespace Tamagotchi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
