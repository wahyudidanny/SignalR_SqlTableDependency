using SignalR_SqlTableDependecy.SubscribeTableDependecies;

namespace SignalR_SqlTableDependecy.MiddlewareExtentions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeProductTableDependecy>();
            service.SubscribeTableDependency();
        }


        public static void UseSalesTableDependency(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeSaleTableDependecy>();
            service.SubscribeTableDependency();
        }
    }
}