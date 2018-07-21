using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjekatZaPosao.Startup))]
namespace ProjekatZaPosao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
