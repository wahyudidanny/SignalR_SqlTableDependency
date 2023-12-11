using SignalR_SqlTableDependecy.SubscribeTableDependecies;

namespace SignalR_SqlTableDependecy.MiddlewareExtentions
{
    public static class ApplicationBuilderExtension
    {

        public static void useSqlTableDependency<T>(this IApplicationBuilder applicationBuilder, string connectionString)
            where T : ISubscribeTableDependency
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<T>();
            service?.SubscribeTableDependency(connectionString);
        }

        // public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder, string connectionString)
        // {
        //     var serviceProvider = applicationBuilder.ApplicationServices;
        //     var service = serviceProvider.GetService<SubscribeProductTableDependecy>();
        //     service?.SubscribeTableDependency(connectionString);

        // }

        // public static void UseSalesTableDependency(this IApplicationBuilder applicationBuilder, string connectionString)
        // {
        //     var serviceProvider = applicationBuilder.ApplicationServices;
        //     var service = serviceProvider.GetService<SubscribeSaleTableDependecy>();
        //     service?.SubscribeTableDependency(connectionString);

        // }
        
    }
}