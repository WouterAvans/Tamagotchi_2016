using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamagotchi_2016.Startup))]
namespace Tamagotchi_2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
