using IMS.Entities;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>(){
                new Product { ProductId = 1, ProductName = "Rations", Quantity = 10, Price = 5 },
                new Product { ProductId = 2, ProductName = "Wooden Planks", Quantity = 5, Price = 10 },
                new Product { ProductId = 3, ProductName = "Jewellery", Quantity = 20, Price = 300 },
                new Product { ProductId = 4, ProductName = "Bricks", Quantity = 0, Price = 7 },
            };
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}