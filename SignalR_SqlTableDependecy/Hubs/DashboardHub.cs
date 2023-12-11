using Microsoft.AspNetCore.SignalR;
using SignalR_SqlTableDependecy.Repositories;

namespace SignalR_SqlTableDependecy.Hubs
{
    public class DashboardHub : Hub
    {
        private readonly ProductRepository _productRepository;
        private readonly SaleRepository _salesRepository;
        private readonly CustomerRepository _customerRepository;

        private readonly string _connectionString = string.Empty;
        public DashboardHub(IConfiguration? configuration)
        {
            _connectionString = configuration?.GetConnectionString("DefaultConnection") ?? "defaultFallbackConnectionString";
            _productRepository = new ProductRepository(_connectionString);
            _salesRepository = new SaleRepository(_connectionString);
            _customerRepository = new CustomerRepository(_connectionString);
        }

        public async Task SendProducts()
        {
            var products = _productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }

        public async Task SendSales()
        {
            var sales = _salesRepository.GetSales();
            await Clients.All.SendAsync("ReceivedSales", sales);
        }

        public async Task SendCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            await Clients.All.SendAsync("ReceivedCustomers", customers);
        }
    }
}