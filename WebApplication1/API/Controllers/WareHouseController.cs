using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.API.Models;
using MijiKalaWebApp.Areas.API.Repository;
using MijiKalaWebApp.Models.DataModels;

namespace MijiKalaWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    public class WareHouseController : Controller
    {
        private IAPIRepository _apiRepository;
        public WareHouseController(IAPIRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        [HttpGet]
        [Route("GetWarehousesList")]
        public async Task<IActionResult> Get()
        {
            var list = await _apiRepository.GetWarehousesList();
            return Ok(list);
        }

        [HttpPost]
        [Route("AddWarehouse")]
        public async Task<IActionResult> Post(WarehouseApiModel warehouse)
        {
            bool result;
            var item = _apiRepository.AddWarehouse(warehouse, out result);
            return Ok(item);
        }

        [HttpDelete]
        [Route("DeleteWarehouse/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiRepository.DeleteWarehouse(id);
            if (result > 0)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpPut]
        [Route("EditWarehouse/{warehouseId}")]
        public async Task<IActionResult> Put(WarehouseApiModel warehouse, int id)
        {
            var result1 = await _apiRepository.DeleteWarehouse(id);
            var result2 = false;
            if (result1 > 0)
            {
                var item = _apiRepository.AddWarehouse(warehouse, out result2);
                if (result2)
                    return Ok(item);
            }
            return BadRequest(new { Del = result1, Add = result2 });
        }
        [HttpGet]
        [Route("GetProductCount/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var list = await _apiRepository.GetProductCountList(id);
            return Ok(list);
        }

        [HttpPost]
        [Route("AddProductNumber/{warehouseId}")]
        public async Task<IActionResult> Post(WarehouseItemApiModel warehouseItem, int warehouseId)
        {
            bool result;
            var item = _apiRepository.AddWarehouseItem(warehouseItem, warehouseId, out result);
            return Ok(item);
        }

        [HttpDelete]
        [Route("DeleteWarehouseItem/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _apiRepository.DeleteWarehouseItem(id);
            if (result > 0)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpPut]
        [Route("EditWarehouseItem/{warehouseId}")]
        public async Task<IActionResult> Put(WarehouseItemApiModel warehouseItem, Guid guid, int warehouseId)
        {
            var result1 = await _apiRepository.DeleteWarehouseItem(guid);
            var result2 = false;
            if (result1 > 0)
            {
                var item = _apiRepository.AddWarehouseItem(warehouseItem, warehouseId, out result2);
                if (result2)
                    return Ok(item);
            }
            return BadRequest(new { Del = result1, Add = result2 });
        }
    }
}