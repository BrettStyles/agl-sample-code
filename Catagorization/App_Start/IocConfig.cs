using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;

namespace Catagorization
{
    /// <summary>
    /// Configure the IOC for WebApi and any implementations required.
    /// </summary>
    public static class IocConfig
    {
        /// <summary>
        /// Register the IOC against the Owin context and return the container.
        /// </summary>
        /// <param name="app">The current Owin context</param>
        /// <returns></returns>
        public static IContainer UseIoc(this IAppBuilder app)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers from the current assembly.
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(assembly);

            //Register interfaces and their implementations
            //TODO: Add implementations

            // Build the container.
            var container = builder.Build();

            return container;
        }
    }
}