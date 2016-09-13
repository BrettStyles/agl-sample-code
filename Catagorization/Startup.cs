using Autofac.Integration.WebApi;
using Catagorization;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Catagorization
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //register implementations with web api support 
            var container = app.UseIoc();

            //create the initial http configuration 
            var config = new HttpConfiguration();

            //map swagger discovery to the existing owin context
            app.UseSwaggerConfig(config);

            //map webapi to the existing owin context
            app.UseWebApiConfig(config);

            //enable autofac for the existing container
            app.UseAutofacMiddleware(container);

            // Configure Web API with the dependency resolver.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
