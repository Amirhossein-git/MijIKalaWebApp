using Microsoft.EntityFrameworkCore;
using MijiKalaWebApp.API.Models;
using MijiKalaWebApp.Contexts;
using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.API.Repository
{
    public class APIRepository : IAPIRepository
    {
        private ProductsContext context;

        public APIRepository(ProductsContext context)
        {
            this.context = context;
        }

        public async Task<List<string>> GetCategories()
        {
            List<string> list = new List<string>();
            list.AddRange(Enum.GetNames(typeof(Category)));
            return list;
        }

        public async Task<List<Product>> GetProductsList(int page, int numberPerPage)
        {
            if (page <= 0 || numberPerPage <= 0)
                return null;
            var list = await context.Products
                .Skip((page - 1) * numberPerPage)
                .Take(numberPerPage)
                .Include(i => i.Comments)
                .ToListAsync();
            return list;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var item = await context.Products
                .Where(i => i.ProductId == id)
                .Select(i => i)
                .Include(i => i.Comments)
                .FirstOrDefaultAsync();
            return item;
        }

        public Product InsertProduct(ProductApiModel insertedProduct, out bool result)
        {
            var product = new Product()
            {
                ProductId = Guid.NewGuid(),
                Category = insertedProduct.Category,
                Slogan = insertedProduct.Slogan,
                DiscountPercentage = insertedProduct.DiscountPercentage,
                HtmlProductDemonstration = insertedProduct.HtmlProductDemonstration,
                Name = insertedProduct.Name,
                Price = insertedProduct.Price,
                ImgSource = insertedProduct.ImgSource,
                ReleaseDate = DateTime.UtcNow,
                Comments = insertedProduct.Comments
            };
            context.Products
                .Add(product);
            result = context.SaveChanges() > 0;
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var itemProduct = await context.Products
                .Where(i => i.ProductId == id)
                .FirstOrDefaultAsync();
            var itemComment = await context.Comments
                .Where(i => i.ProductId == id)
                .Select(i => i)
                .ToListAsync();
            if (itemProduct == null)
                return false;
            context.Products
                .Remove(itemProduct);
            context.Comments
                .RemoveRange(itemComment);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Warehouse>> GetWarehousesList()
        {
            var list = await context.Warehouses
                .Select(i => i)
                .ToListAsync();
            return list;
        }

        public async Task<List<WarehouseItem>> GetProductCountList(Guid id)
        {
            var ExactList = new List<WarehouseItem>();
            var SummeryList = await context.Warehouses
                .Include(i => i.WarehouseItems)
                .Select(i => i.WarehouseItems)
                .ToListAsync();

            foreach (var item in SummeryList)
            {
                foreach (var warehouseItem in item)
                {
                    if (warehouseItem.Product.ProductId == id)
                    {
                        ExactList.Add(warehouseItem);
                    }
                }
            }

            return ExactList;
        }

        public Warehouse AddWarehouse(WarehouseApiModel insertedWarehouse, out bool result)
        {
            var warehouse = new Warehouse()
            {
                Name = insertedWarehouse.Name,
                Adress = insertedWarehouse.Adress,
                Manager = insertedWarehouse.Manager,
                Telephone = insertedWarehouse.Telephone,
                WarehouseItems = new List<WarehouseItem>()
            };

            context.Warehouses
                .Add(warehouse);
            result = context.SaveChanges() > 0;
            return warehouse;
        }

        public async Task<int> DeleteWarehouse(int id)
        {
            var item = await context.Warehouses
                .Where(i => i.WarehouseId == id)
                .FirstOrDefaultAsync();
            context.Warehouses.Remove(item);
            return await context.SaveChangesAsync();
        }

        public WarehouseItem AddWarehouseItem(WarehouseItemApiModel insertedWarehouse, int warehouseId, out bool result)
        {
            var warehouseItem = new WarehouseItem()
            {
                WraehouseItemId = Guid.NewGuid(),
                NumberInWarehouse = insertedWarehouse.NumberInWarehouse,
                Product = context.Products.Where(i => i.ProductId == insertedWarehouse.ProductId).FirstOrDefault(),
            };
            context.Warehouses
                .Where(i => i.WarehouseId == warehouseId)
                .Include(i => i.WarehouseItems)
                .Select(i => i.WarehouseItems)
                .FirstOrDefault()
                .Add(warehouseItem);
            result = context.SaveChanges() > 0;
            return warehouseItem;
        }

        public async Task<int> DeleteWarehouseItem(Guid guid)
        {
            var item = await context.WarehouseItems
                .Where(i => i.WraehouseItemId == guid)
                .FirstOrDefaultAsync();
            context.WarehouseItems.Remove(item);
            return await context.SaveChangesAsync();
        }
    }
}
