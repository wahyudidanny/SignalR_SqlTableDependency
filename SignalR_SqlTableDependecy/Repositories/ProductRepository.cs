using System.Data;
using System.Data.SqlClient;
using SignalR_SqlTableDependecy.Models;

namespace SignalR_SqlTableDependecy.Repositories
{
    public class ProductRepository
    {

        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();
            Product product;

            var data = GetProductDetailFromDb();
            foreach (DataRow row in data.Rows)
            {
                product = new Product
                {


                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Category = row["Category"].ToString(),
                    Price = Convert.ToDecimal(row["Price"])
                };
                products.Add(product);
            }

            return products;

        }



        public DataTable GetProductDetailFromDb()
        {
            var query = "SELECT Id, Name, Category, Price FROM Product";
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
    }
}