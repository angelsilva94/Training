using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Shop.Startup))]

namespace Shop {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
