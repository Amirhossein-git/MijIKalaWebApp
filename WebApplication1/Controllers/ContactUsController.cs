using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ILogger<ContactUsController> _logger;

        public ContactUsController(ILogger<ContactUsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Info()
        {
            return View();
        }

    }
}