using SignalR_SqlTableDependecy.Hubs;
using SignalR_SqlTableDependecy.SubscribeTableDependecies;

namespace SignalR_SqlTableDependecy
{
    public static class Setup
    {
        public static void RegisterDependency(this WebApplicationBuilder builder)
        {

            builder.Services.AddSingleton<DashboardHub>();
            builder.Services.AddSingleton<SubscribeProductTableDependecy>();
            builder.Services.AddSingleton<SubscribeSaleTableDependecy>();
            builder.Services.AddSingleton<SubscribeCustomerTableDependecy>();

        }
    }
}