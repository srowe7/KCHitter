using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KCHitterDAD.Startup))]
namespace KCHitterDAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
