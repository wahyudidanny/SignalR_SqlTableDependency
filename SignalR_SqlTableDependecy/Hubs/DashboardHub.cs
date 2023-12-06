using Microsoft.AspNetCore.SignalR;
using SignalR_SqlTableDependecy.Repositories;

namespace SignalR_SqlTableDependecy.Hubs
{
    public class DashboardHub : Hub
    {

        private readonly ProductRepository _productRepository;
        private readonly string _connectionString = string.Empty;
        public DashboardHub(IConfiguration? configuration)
        {
            _connectionString = configuration?.GetConnectionString("DefaultConnection") ?? "defaultFallbackConnectionString";
            _productRepository = new ProductRepository(_connectionString);
        }

        public async Task SendProducts()
        {
            var products = _productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }

    }
}