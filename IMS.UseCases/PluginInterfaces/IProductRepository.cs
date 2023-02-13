using IMS.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string productName);
    }
}