using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Components
{
    public class CommentsViewComponent:ViewComponent
    {
            private IProductsRepository _productsRepository;
            public CommentsViewComponent(IProductsRepository productsRepository)
            {
                _productsRepository = productsRepository;
            }
            public async Task<IViewComponentResult> InvokeAsync(Guid id, int n)
            {
                var comment = await _productsRepository.GetCommentsByProductsIdAsync(id);
                return View(comment[n]);
            }
    }
}
