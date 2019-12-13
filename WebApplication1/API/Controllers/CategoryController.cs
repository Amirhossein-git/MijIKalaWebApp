using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Areas.API.Repository;

namespace MijiKalaWebApp.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IAPIRepository _apiRepository;

        public CategoryController(IAPIRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        [HttpGet]
        [Route("GetCategoryList")]
        public async Task<IActionResult> Get()
        {
            var list = await _apiRepository.GetCategories();
            return Ok(list);
        }
    }
}