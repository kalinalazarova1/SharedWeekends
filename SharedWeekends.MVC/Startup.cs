using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedWeekends.MVC.Startup))]

namespace SharedWeekends.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
