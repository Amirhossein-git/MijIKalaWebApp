using MijiKalaWebApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.ViewModels
{
    public class ProductsViewModel
    {
        public string ProductTiltle { get; set; }

        public Category Category { get; set; }

        public List<Guid> IdList { get; set; }
    
    }
}
