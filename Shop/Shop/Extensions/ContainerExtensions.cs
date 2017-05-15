using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;

namespace Shop.Extensions
{
    internal static class ContainerExtensions
    {
        public static IContainer FinalizeAndBuild(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            return containerBuilder.Build();
        }
    }
}