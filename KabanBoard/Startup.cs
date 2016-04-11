using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KabanBoard.Startup))]
namespace KabanBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
