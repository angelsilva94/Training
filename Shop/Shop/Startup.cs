using Microsoft.Owin;
using Owin;
using Shop.Ioc;
using System.Web.Http;
using Shop.Extensions;
using Autofac;
using Autofac.Integration.WebApi;


[assembly: OwinStartup(typeof(Shop.Startup))]

namespace Shop {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var containerBuilder = new ContainerFactory();
            var container = containerBuilder.CreateBuilder().FinalizeAndBuild();
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}