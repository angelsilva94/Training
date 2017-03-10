using Autofac;
using LoginRegister.Models;
using Shop.Models.DBModel;
using Shop.Models.Interfaces;

namespace Shop.Ioc {

    public class ContainerFactory {

        public ContainerBuilder CreateBuilder() {
            var builder = new ContainerBuilder();
            builder.RegisterType<User>().As<IUser>();
            //builder.RegisterType<CheckUser>().As<ICheckUser>();
            return builder;
        }
    }
}