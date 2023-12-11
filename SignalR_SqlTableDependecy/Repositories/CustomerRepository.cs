using System.Data;
using System.Data.SqlClient;
using SignalR_SqlTableDependecy.Models;

namespace SignalR_SqlTableDependecy.Repositories
{
    public class CustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {

            List<Customer> customers = new List<Customer>();
            Customer customer;

            var data = GetCustomerDetailFromDb();
            foreach (DataRow row in data.Rows)
            {
                customer = new Customer
                {
                    id = Convert.ToInt32(row["id"]),
                    name = row["name"].ToString(),
                    gender = row["gender"].ToString(),
                    mobile = row["mobile"].ToString(),
                };
                customers.Add(customer);
            }

            return customers;

        }

        public DataTable GetCustomerDetailFromDb()
        {
            var query = "SELECT Id, Name, Gender, Mobile FROM Customer";
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