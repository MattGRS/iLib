using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoBiblioteca.Startup))]
namespace ProjetoBiblioteca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
