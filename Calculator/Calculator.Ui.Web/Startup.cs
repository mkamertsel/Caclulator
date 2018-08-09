using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calculator.Ui.Web.Startup))]
namespace Calculator.Ui.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
