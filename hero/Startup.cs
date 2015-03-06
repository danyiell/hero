using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hero.Startup))]
namespace hero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
