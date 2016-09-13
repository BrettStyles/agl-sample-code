using Owin;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Catagorization
{
    /// <summary>
    /// Configure webapi route discovery against the owin context with camel case json enabled.
    /// </summary>
    public static class WebApiConfig
    {
        public static void UseWebApiConfig(this IAppBuilder app, HttpConfiguration config)
        {
            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}
