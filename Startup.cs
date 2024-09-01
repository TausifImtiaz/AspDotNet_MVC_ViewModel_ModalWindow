using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ViewModel_ModalWindow.Startup))]
namespace MVC_ViewModel_ModalWindow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
