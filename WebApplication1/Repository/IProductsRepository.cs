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
    public interface IProductsRepository
    {
        public Task<List<Comment>> GetCommentsByProductsIdAsync(Guid id);

        public Task<Product> GetProductByIdAsync(Guid id);

        public Task<List<Product>> GetFiveNewProductsAsync();
        
        public Task<List<Product>> GetFiveWithDiscountProductsAsync();

        public Task<List<Guid>> WithDiscountsAsync();

        public Task<List<Guid>> TheNewestsAsync();

        public Task<List<Guid>> InCategorysAsync(Category category);

        public Task<List<Guid>> SearchResaultAsync(string text);

    }
}
