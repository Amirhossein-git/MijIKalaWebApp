using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MijiKalaWebApp.API.Models;
using MijiKalaWebApp.Models.DataModels;

namespace MijiKalaWebApp.Areas.API.Repository
{
    public interface IAPIRepository
    {
        Warehouse AddWarehouse(WarehouseApiModel insertedWarehouse, out bool result);
        WarehouseItem AddWarehouseItem(WarehouseItemApiModel insertedWarehouse, int warehouseId, out bool result);
        Task<bool> DeleteProduct(Guid id);
        Task<int> DeleteWarehouse(int id);
        Task<int> DeleteWarehouseItem(Guid guid);
        Task<List<string>> GetCategories();
        Task<Product> GetProductById(Guid id);
        Task<List<WarehouseItem>> GetProductCountList(Guid id);
        Task<List<Product>> GetProductsList(int page, int numberPerPage);
        Task<List<Warehouse>> GetWarehousesList();
        Product InsertProduct(ProductApiModel insertedProduct, out bool result);
    }
}