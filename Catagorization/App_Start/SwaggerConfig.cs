using System.Web.Http;
using Owin;
using Swashbuckle.Application;

namespace Catagorization
{
    /// <summary>
    /// Enable swagger discovery for AZURE Api Apps from http://agl-sample.azurewebsites.net//swagger
    /// </summary>
    public static class SwaggerConfig
    {
        //Register discovery against the Owin context for the existing http configuration as version 1 of the API
        public static void UseSwaggerConfig(this IAppBuilder app, HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Catagorization");
                })
                .EnableSwaggerUi(c =>
                {
                    c.DisableValidator();
                });
        }
    }
}
