using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Repository
{
    public interface IAdminRepository
    {
        public Task<string> ReadWorkersNews();

        public Task<List<Warehouse>> GetWarehousesAsync();

        public Task<WarehouseItem> GetOneWarehouseItemAsync(Guid guid);

        public Task<Warehouse> GetRelatedWarehouseAsync(int id);

        public Task<List<WarehouseItem>> GetRelatedWarehouseItemAsync(int id);

        public Task<int> DeleteWarehouse(int id);

        public Task<int> AddWarehouse(Warehouse warehouse);
        
        public Task<int> DeleteWarehouseItem(Guid guid);

        public Task<int> AddWarehouseItem(WarehouseItem warehouseItem);

        public Task<Product> GetProductByIdAsync(Guid id);

        public Task<int> DeleteProduct(Guid guid);

        public Task<int> AddProduct(Product product);
    }
}
