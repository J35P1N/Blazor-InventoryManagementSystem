using IMS.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string productName);

        Task<Product> GetProductByIdAsync(int id);

        Task UpdateProductAsync(Product product);
    }
}