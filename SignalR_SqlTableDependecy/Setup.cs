using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_SqlTableDependecy.Hubs;
using SignalR_SqlTableDependecy.MiddlewareExtentions;
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

			// var connectionString = builder.Configuration.GetConnectionString("Dashboard");
			// builder.Services.AddDbContext<DashboardDbContext>(options => options.UseSqlServer(connectionString));
			// builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
			// builder.Services.AddMemoryCache();
			// builder.Services.AddScoped<T_DataDetail_Rotasi_Sensus_Services>();
			// builder.Services.AddScoped<DropDownlistServices>();
			// builder.Services.AddScoped<DataGridViewServices>();
			// builder.Services.AddScoped<ExportServices>();
			// builder.Services.AddScoped<AdditionalInfoServices>();
			// builder.Services.AddScoped<RotasiSensusServices>();
		}
    }
}