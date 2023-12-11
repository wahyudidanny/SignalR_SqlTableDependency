using SignalR_SqlTableDependecy.Hubs;
using SignalR_SqlTableDependecy.Models;
using TableDependency.SqlClient;

namespace SignalR_SqlTableDependecy.SubscribeTableDependecies
{
    public class SubscribeSaleTableDependecy : ISubscribeTableDependency
    {
        SqlTableDependency<Sales>? tableDependency;
        DashboardHub dashboardHub;

        public SubscribeSaleTableDependecy(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Sales>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Sales)} SqlTableDependecy error: {e.Error.Message}");
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Sales> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                await dashboardHub.SendSales();

            }
        }

    }
}