using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Health_Information_System.Startup))]
namespace Health_Information_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
