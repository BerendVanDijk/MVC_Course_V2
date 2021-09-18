using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Course_V2.Startup))]
namespace MVC_Course_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
