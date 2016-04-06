using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamagotchi_prog.Startup))]
namespace Tamagotchi_prog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
