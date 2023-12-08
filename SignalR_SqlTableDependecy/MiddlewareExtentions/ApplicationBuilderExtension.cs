using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_SqlTableDependecy.SubscribeTableDependecies;

namespace SignalR_SqlTableDependecy.MiddlewareExtentions
{
    public static class ApplicationBuilderExtension
    {

        public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder){

      
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeProductTableDependecy>();
            service.SubscribeTableDependency();
        }
    }
}