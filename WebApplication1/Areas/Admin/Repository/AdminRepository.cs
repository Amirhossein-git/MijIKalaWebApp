using Microsoft.EntityFrameworkCore;
using MijiKalaWebApp.Contexts;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private ProductsContext _context;
        public AdminRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<string> ReadWorkersNews()
        {
            var file = await File.ReadAllLinesAsync("C:\\Users\\Amirhossein\\source\\repos\\MijiKalaWebApp\\WebApplication1\\wwwroot\\Area\\News.txt");
            string text = "به نام خدا<br />نتقخقتخق";
            foreach (var item in file)
            {
                text = text.Insert(text.Length - 1, item);
                text = text.Insert(text.Length - 1, "<br />");
            }
            return text;
        }

        public async Task<List<Warehouse>> GetWarehousesAsync()
        {
            var list = await _context.Warehouses
                .Select(i => i)
                .ToListAsync();
            return list;
        }

        public async Task<WarehouseItem> GetOneWarehouseItemAsync(Guid guid)
        {
            var item = await _context.WarehouseItems
                .Where(i => i.WraehouseItemId == guid)
                .Include(i => i.Product)
                .FirstOrDefaultAsync();
            return (item);
        }

        public async Task<Warehouse> GetRelatedWarehouseAsync(int id)
        {
            var item = await _context.Warehouses
                .Where(i => i.WarehouseId == id)
                .FirstOrDefaultAsync();
            return item;
        }
        public async Task<List<WarehouseItem>> GetRelatedWarehouseItemAsync(int id)
        {
            var list = await _context.WarehouseItems
                .Where(i => i.Warehouseid == id)
                .Include(i => i.Product)
                .ToListAsync();
            return list;
        }

        public async Task<int> DeleteWarehouse(int id)
        {
            var list = await _context.Warehouses
                .Where(i => i.WarehouseId == id)
                .Select(i => i)
                .ToListAsync();
            if (list.Count == 0)
                return -1;
            var item = await _context.Warehouses
                .Where(i => i.WarehouseId == id)
                .FirstOrDefaultAsync();
            _context.Warehouses.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteWarehouseItem(Guid guid)
        {
            var item = await _context.WarehouseItems
                .Where(i => i.WraehouseItemId == guid)
                .FirstOrDefaultAsync();
            if (item == null)
                return -1;
            _context.WarehouseItems.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddWarehouseItem(WarehouseItem warehouseItem)
        {
            _context.WarehouseItems.Add(warehouseItem);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            if (await _context.Products.Where(i => i.ProductId == id).CountAsync() == 0)
            {
                return null;
            }
            var item = await _context.Products
           .Where(i => i.ProductId == id)
           .Select(i => i)
           .Include(i => i.Comments)
           .FirstOrDefaultAsync();
            return item;
        }

        public async Task<int> DeleteProduct(Guid guid)
        {
            var item = await _context.Products
                .Where(i => i.ProductId == guid)
                .FirstOrDefaultAsync();
            if (item == null)
                return -1;
            _context.Products.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddProduct(Product product)
        {
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }
    }
}
