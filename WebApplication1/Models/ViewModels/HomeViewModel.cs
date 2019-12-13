using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MijiKalaWebApp.Models.DataModels;

namespace MijiKalaWebApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> NewProductsList { get; set; }
        
        public List<Product> UnderPricedProductsList { get; set; }
    
    }
}
