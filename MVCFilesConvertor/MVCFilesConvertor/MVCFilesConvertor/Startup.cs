using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFilesConvertor.Startup))]
namespace MVCFilesConvertor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
