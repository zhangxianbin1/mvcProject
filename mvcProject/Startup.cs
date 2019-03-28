using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcProject.Startup))]
namespace mvcProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
