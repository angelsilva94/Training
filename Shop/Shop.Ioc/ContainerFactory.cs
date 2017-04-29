using Autofac;
using Shop.Models.DBModel;
using Shop.Models.Interfaces;

namespace Shop.Ioc {

    public class ContainerFactory {

        public ContainerBuilder CreateBuilder() {
            var builder = new ContainerBuilder();
            builder.RegisterType<Address>().As<IAddress>();
            builder.RegisterType<Brand>().As<IBrand>();
            builder.RegisterType<Category>().As<ICategory>();
            builder.RegisterType<Order>().As<IOrder>();
            builder.RegisterType<OrderDetail>().As<IOrderDetail>();
            builder.RegisterType<IOrderStatus>().As<IOrderStatus>();
            builder.RegisterType<Product>().As<IProduct>();
            builder.RegisterType<ProductCategory>().As<IProductCategory>();
            builder.RegisterType<ReviewProduct>().As<IReviewProduct>();
            builder.RegisterType<User>().As<IUser>();
            builder.RegisterType<UserInfo>().As<IUserInfo>();
            builder.RegisterType<UserType>().As<IUserType>();
            //builder.RegisterType<CheckUser>().As<ICheckUser>();
            return builder;
        }
    }
}