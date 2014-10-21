using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctioneerWeb.Startup))]
namespace AuctioneerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
