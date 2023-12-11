using System.Data;
using System.Data.SqlClient;
using SignalR_SqlTableDependecy.Models;

namespace SignalR_SqlTableDependecy.Repositories
{
    public class SaleRepository
    {

        private readonly string _connectionString;

        public SaleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetSaleDetailsFromDb()
        {
            var query = "SELECT Id, Customer, Amount, PurchaseOn FROM sales";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        }


        public List<Sales> GetSales()
        {

            List<Sales> sales = new List<Sales>();
            Sales sale;

            var data = GetSaleDetailsFromDb();
            foreach (DataRow row in data.Rows)
            {
                sale = new Sales
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Customer = row["Customer"].ToString(),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    PurchaseOn =  Convert.ToDateTime(row["PurchaseOn"].ToString())
                };
                sales.Add(sale);
            }

            return sales;

        }


    }
}