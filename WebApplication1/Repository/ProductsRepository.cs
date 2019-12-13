using Microsoft.EntityFrameworkCore;
using MijiKalaWebApp.Contexts;
using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsContext context;

        public ProductsRepository(ProductsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comment>> GetCommentsByProductsIdAsync(Guid id)
        {
            var product = await context.Products
                .Where(i => i.ProductId == id)
                .Select(i => i)
                .ToListAsync();
            var list = await context.Comments
                .Where(i => i.ProductId == id)
                .Select(i => i)
                .ToListAsync();
            return list;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var item = await context.Products
               .Where(i => i.ProductId == id)
               .Select(i => i)
               .Include(i => i.Comments)
               .FirstOrDefaultAsync();
            return item;
        }

        public async Task<List<Guid>> WithDiscountsAsync()
        {
            var list = await context.Products
                .Where(i => i.DiscountPercentage != 0)
                .Select(i => i.ProductId)
                .ToListAsync();
            return list;
        }

        public async Task<List<Guid>> TheNewestsAsync()
        {
            var list = await context.Products
                .OrderByDescending(i => i.ReleaseDate)
                .Select(i => i.ProductId)
                .ToListAsync();
            return list;
        }

        public async Task<List<Guid>> InCategorysAsync(Category category)
        {
            var list = await context.Products
               .Where(i => i.Category == category)
               .Select(i => i.ProductId)
               .ToListAsync();
            return list;
        }

        public async Task<List<Guid>> SearchResaultAsync(string text)
        {
            var list = await context.Products
               .Where(i => i.Name.Contains(text))
               .Select(i => i.ProductId)
               .ToListAsync();
            return list;
        }

        public async Task<List<Product>> GetFiveNewProductsAsync()
        {
            var list = await context.Products
               .OrderByDescending(i => i.ReleaseDate)
               .Take(5)
               .Select(i => i)
               .ToListAsync();
            return list;
        }

        public async Task<List<Product>> GetFiveWithDiscountProductsAsync()
        {

            var list = await context.Products
                .OrderByDescending(i => i.DiscountPercentage)
                .Take(5)
                .Select(i => i)
                .ToListAsync();
            return list;
        }
    }
}
