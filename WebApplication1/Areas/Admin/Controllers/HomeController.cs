using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Areas.Admin.Models;
using MijiKalaWebApp.Areas.Admin.Repository;
using MijiKalaWebApp.Classes;
using MijiKalaWebApp.Consts;
using MijiKalaWebApp.Models.DataModels;

namespace MijiKalaWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConst.Admin)]
    public class HomeController : Controller
    {
        private IAdminRepository _adminRepository;
        public HomeController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<IActionResult> Home()
        {
            var news = await _adminRepository.ReadWorkersNews();
            ViewBag.workersNews = news;
            return View();
        }
        public async Task<IActionResult> Info(InfoOrder order)
        {
            ContainInfoViewModel containInfo = new ContainInfoViewModel();
            if (order.Function == "WarehouseId")
            {
                var warehouse = await _adminRepository.GetRelatedWarehouseAsync(order.IntId);
                containInfo.InfoItems = new List<InfoItem>()
                {
                    new InfoItem()
                    {
                        Title = warehouse.Name,
                        Description = $"آدرس:{warehouse.Adress}<br />شماره:{warehouse.Telephone}"
                            + $"<br />مدیر:{warehouse.Manager}<br />شناسه:{warehouse.WarehouseId}"
                    }
                };
                int i = 1;
                foreach (var item in await _adminRepository.GetRelatedWarehouseItemAsync(warehouse.WarehouseId))
                {
                    var newInfoItem = new InfoItem()
                    {
                        Title = $"{i} : شناسه آیتم" + item.WraehouseItemId.ToString(),
                        Description = $"شناسه محصول:{item.Product.ProductId.ToString()}<br />تعداد:{item.NumberInWarehouse}"
                    };
                    containInfo.InfoItems.Add(newInfoItem);
                    i++;
                }
            }
            if (containInfo.Title != null || containInfo.InfoItems != null)
                return View(containInfo);
            var defaultContainInfo = new ContainInfoViewModel()
            {
                InfoItems = new List<InfoItem>()
                {
                    new InfoItem()
                    {
                        Title ="کاربر عزیز",
                        Description="موردی برای نمایش نیست"
                    }
                }
            };
            return View(defaultContainInfo);
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var item = new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Category = viewModel.Category,
                    DiscountPercentage = viewModel.DiscountPercentage,
                    Comments = viewModel.Comments,
                    ImgSource = viewModel.ImgSource,
                    HtmlProductDemonstration = viewModel.HtmlProductDemonstration,
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    ReleaseDate = DateTime.UtcNow,
                    Slogan = viewModel.Slogan
                };
                await _adminRepository.AddProduct(item);
                return View();
            }
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeOrRemoveProduct(Guid guid, bool delete = false)
        {
            if (await _adminRepository.GetProductByIdAsync(guid) != null)
            {
                var product = await _adminRepository.GetProductByIdAsync(guid);
                ViewBag.guid = guid;
                var item = new ProductAdminViewModel()
                {
                    Category = product.Category,
                    DiscountPercentage = product.DiscountPercentage,
                    Comments = product.Comments,
                    ImgSource = product.ImgSource,
                    HtmlProductDemonstration = product.HtmlProductDemonstration,
                    Name = product.Name,
                    Price = product.Price,
                    Slogan = product.Slogan
                };
                return View("ChangeOrRemove/ChangeOrRemoveProduct", item);
            }
            if (delete == true)
            {
                await _adminRepository.DeleteProduct(guid);
                return View("ChangeOrRemove/GetId");
            }
            if (guid != Guid.Empty)
            {
                ModelState.AddModelError("", "شناسه نامعتبر است");
            }
            return View("ChangeOrRemove/GetId");
        }
        [HttpPost]
        public async Task<IActionResult> ChangeOrRemoveProduct([FromRoute]Guid guid, [FromBody]ProductAdminViewModel viewModel)
        {
            if (viewModel.Name != null && viewModel.Category != 0 && viewModel.Price != 0)
            {
                var changedItem = new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Category = viewModel.Category,
                    DiscountPercentage = viewModel.DiscountPercentage,
                    Comments = viewModel.Comments,
                    ImgSource = viewModel.ImgSource,
                    HtmlProductDemonstration = viewModel.HtmlProductDemonstration,
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    ReleaseDate = DateTime.UtcNow,
                    Slogan = viewModel.Slogan
                };
                await _adminRepository.DeleteProduct(guid);
                await _adminRepository.AddProduct(changedItem);
                return View("ChangeOrRemove/GetId");
            }

            ModelState.AddModelError("", "فیلد نام و دسته بندی و قیمت اجباری است");
            return View("ChangeOrRemove/ChangeOrRemoveProduct", viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> WarehouseItem(Guid guid)
        {
            if (guid != Guid.Empty)
            {
                await _adminRepository.DeleteWarehouseItem(guid);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WarehouseItem(WarehouseItemAdminViewModel viewModel)
        {
            if (viewModel == null)
            {
                return View();
            }
            else if (viewModel.Function == "Add")
            {
                var item = new WarehouseItem()
                {
                    WraehouseItemId = Guid.NewGuid(),
                    NumberInWarehouse = viewModel.NumberInWarehouse,
                    Warehouseid = viewModel.WarehouseId,
                    Product = await _adminRepository.GetProductByIdAsync(viewModel.ProductId)
                };
                var result = await _adminRepository.AddWarehouseItem(item);

                return View();
            }
            else if (viewModel.Function == "Edit")
            {
                var previous = await _adminRepository.GetOneWarehouseItemAsync(viewModel.WarehouseItemId);
                var newOne = new WarehouseItem()
                {
                    WraehouseItemId = viewModel.WarehouseItemId,
                    NumberInWarehouse = viewModel.NumberInWarehouse,
                    Warehouseid = previous.Warehouseid,
                    Product = previous.Product
                };
                var result1 = await _adminRepository.DeleteWarehouseItem(previous.WraehouseItemId);
                var result2 = await _adminRepository.AddWarehouseItem(newOne);
                var result = result1 == 1 && result2 == 1;

                return View();
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public async Task<IActionResult> Warehouse(int id = 0)
        {
            if (id != 0)
            {
                await _adminRepository.DeleteWarehouse(id);
            }
            var model = new WarehouseAdminViewModel()
            {
                Warehouses = await _adminRepository.GetWarehousesAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Warehouse(Warehouse warehouse)
        {
            await _adminRepository.AddWarehouse(warehouse);
            var model = new WarehouseAdminViewModel()
            {
                Warehouses = await _adminRepository.GetWarehousesAsync(),
                AddedWarehouse = warehouse
            };
            return View(model);
        }
    }
}