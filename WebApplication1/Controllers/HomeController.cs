using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using MijiKalaWebApp.Models.ViewModels;
using MijiKalaWebApp.Repository;
//۱۲۳۴۵۶۷۸۹۰

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductsRepository _productsRepository;

        public HomeController(ILogger<HomeController> logger, IProductsRepository repository)
        {
            _logger = logger;
            _productsRepository = repository;
        }

        public async Task<IActionResult> Search(int page, string searchText)
        {
            var list = await _productsRepository.SearchResaultAsync(searchText);
            ViewBag.page = page;
            ViewBag.numberOfSearchResault = list.Count;
            ViewBag.searchText = searchText;
            return View(list);
        } 
        public async Task<IActionResult> Home(bool signedUp = false, bool signedIn = false)
        {
            ViewBag.signedUp = signedUp;
            ViewBag.signedIn = signedIn;
            var model = new HomeViewModel()
            {
                NewProductsList = await _productsRepository.GetFiveNewProductsAsync(),
                UnderPricedProductsList = await _productsRepository.GetFiveWithDiscountProductsAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> TheNewest(int page)
        {
            var list = await _productsRepository.TheNewestsAsync();
            ViewBag.page = page;
            ViewBag.numberOfAll = list.Count;
            return View(list);
        }

        public async Task<IActionResult> WithDiscount(int page)
        {
            var list = await _productsRepository.WithDiscountsAsync();
            ViewBag.page = page;
            ViewBag.numberWithDiscount = list.Count;
            return View(list);
        }

        public async Task<IActionResult> Products(Category category, int page)
        {
            ViewBag.page = page;
            var translatedCategory = new Dictionary<Category, string>();
            translatedCategory.Add(Category.HomeAppliances, "لوازم خوانگی");
            translatedCategory.Add(Category.Book, "کتاب");
            translatedCategory.Add(Category.Stationery, "لوازم التحریر");
            translatedCategory.Add(Category.Bag, "کیف");
            translatedCategory.Add(Category.Electronical, "لوازم الکترونیکی");
            translatedCategory.Add(Category.Clothes, "پوشاک");
            translatedCategory.Add(Category.Sport, "ورزشی");
            translatedCategory.Add(Category.Food, "غذایی");

            var productsViewModel = new ProductsViewModel()
            {
                ProductTiltle = translatedCategory[category],
                Category = category,
                IdList =await _productsRepository.InCategorysAsync(category)
            };
            ViewBag.numberInCategory =productsViewModel.IdList.Count;
            return View(productsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
