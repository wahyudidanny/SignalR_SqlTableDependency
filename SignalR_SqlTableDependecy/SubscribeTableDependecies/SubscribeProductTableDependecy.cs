using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_SqlTableDependecy.Hubs;
using SignalR_SqlTableDependecy.Models;
using TableDependency.SqlClient;

namespace SignalR_SqlTableDependecy.SubscribeTableDependecies
{
    public class SubscribeProductTableDependecy
    {

        SqlTableDependency<Product> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeProductTableDependecy(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency()
        {
            string connectionString = "Data Source=10.100.1.26;Initial Catalog=NewFPSTesting;User ID=sa;Password=Jakarta123;Pooling=true;TrustServerCertificate=Yes;";
            tableDependency = new SqlTableDependency<Product>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependecy error: {e.Error.Message}");
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendProducts();

            }
        }


    }
}