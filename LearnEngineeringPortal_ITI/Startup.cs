
using Microsoft.Owin;
using Owin;
using Odishadtet.DAL;
using Odishadtet.Models;

[assembly: OwinStartupAttribute(typeof(TNDET.Startup))]
namespace TNDET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //services..AddMvc();
        //    services.Add();
        //    // Add application services.
        //    services.AddTransient<IStudentService, StudentService>();
        //}
    }
}

