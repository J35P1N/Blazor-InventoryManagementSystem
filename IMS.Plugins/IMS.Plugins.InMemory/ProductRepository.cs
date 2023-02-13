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

        public Task AddProductAsync(Product product)
        {
            if(_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;

            _products.Add(product);

            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product product)
        {
            if(_products.Any(x => 
                x.ProductId != product.ProductId &&
                x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var productToEdit = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if(productToEdit != null){
                productToEdit.ProductName = product.ProductName;
                productToEdit.Price = product.Price;
                productToEdit.Quantity = product.Quantity;
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var inv = _products.First(x => x.ProductId == id);
            var newInv = new Product{
                ProductId = inv.ProductId,
                ProductName = inv.ProductName,
                Quantity = inv.Quantity,
                Price = inv.Price
            };

            return await Task.FromResult(newInv);
        }
    }
}