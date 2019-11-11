using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(locker_reading.Startup))]
namespace locker_reading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
