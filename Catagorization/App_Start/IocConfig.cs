
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;
using Catagorization.Controllers;
using Configuration;
using PeopleService.Providers;

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

            builder.RegisterType<PetSorter>().As<IPetSorter>();

            RegisterExternalServices(builder);

            // Build the container.
            var container = builder.Build();

            return container;
        }

        //Register services from external libraries
        private static void RegisterExternalServices(ContainerBuilder builder)
        {
            builder.RegisterType<Settings>().As<ISettings>();
            builder.RegisterType<PetOwnerService>().As<IPetOwnerService>();
        }
    }
}