using IMS.Entities;
using IMS.UseCases.PluginInterfaces;
using System.Reflection.Metadata.Ecma335;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Food", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 1, InventoryName = "Wood", Quantity = 5, Price = 4 },
                new Inventory { InventoryId = 1, InventoryName = "Gold", Quantity = 20, Price = 6 },
                new Inventory { InventoryId = 1, InventoryName = "Stone", Quantity = 0, Price = 8 },
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if(_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
