using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalBugTracker.Startup))]
namespace FinalBugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
