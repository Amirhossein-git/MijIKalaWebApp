using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Models.DataModels;
using MijiKalaWebApp.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MijiKalaWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IActionResult> DetailedProducts(Guid id)
        {
            Product product =await _productsRepository.GetProductByIdAsync(id) ;
            if (product.ImgSource == null)
                product.ImgSource = "~/css/Images/default.png";
            return View(product);
        }
    }
}
