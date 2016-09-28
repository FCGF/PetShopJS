using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetShopJS.Startup))]
namespace PetShopJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
