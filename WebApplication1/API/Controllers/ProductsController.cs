using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.API.Models;
using MijiKalaWebApp.Areas.API.Repository;
using MijiKalaWebApp.Models.DataModels;

namespace MijiKalaWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class ProductsController : Controller
    {
        private IAPIRepository _apiRepository;
        public ProductsController(IAPIRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        [HttpGet]
        [Route("GetProductsForPage/{page}/{numberPerPage}")]
        public async Task<IActionResult> Get(int page, int numberPerPage)
        {
            if (page <= 0 || numberPerPage <= 0)
                return BadRequest("Page or NumberPerPage was less than zero.");
            if (numberPerPage > 100)
            {
                return BadRequest("NumberPerPage was too big.");
            }
            var list = await _apiRepository.GetProductsList(page, numberPerPage);
            return Ok(list);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _apiRepository.GetProductById(id);
            if (item != null)
            {
                return Ok(new { Message = true, Product = item });
            }
            return BadRequest(new { Message = "Incorrect Id.", Product = item });
        }

        [HttpPost]
        [Route("InsertProduct")]
        public async Task<IActionResult> Post(ProductApiModel productApiModel)
        {
            bool result;
            var product = _apiRepository.InsertProduct(productApiModel, out result);
            if (result)
            {
                return Ok(new { Message = true, Product = product });
            }
            else
                return BadRequest(new { Message = false, Product = product });
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _apiRepository.DeleteProduct(id);
            if (result)
                return Ok(result);
            return BadRequest(false);
        }

        [HttpPut]
        [Route("EditProduct/{id}")]
        public async Task<IActionResult> Put(ProductApiModel product, Guid id)
        {
            bool insertResult;
            var removeResult = await _apiRepository.DeleteProduct(id);
            _apiRepository.InsertProduct(product, out insertResult);

            if (removeResult && insertResult)
                return Ok(removeResult && insertResult);
            return BadRequest(false);
        }

    }
}