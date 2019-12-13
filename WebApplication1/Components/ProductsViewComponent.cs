using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using MijiKalaWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        private IProductsRepository _productsRepository;
        public ProductsViewComponent(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var product = await _productsRepository.GetProductByIdAsync(id);
            if (product.ImgSource == null)
                product.ImgSource = "~/css/Images/default.png";
            return View(product);
        }
    }
}
