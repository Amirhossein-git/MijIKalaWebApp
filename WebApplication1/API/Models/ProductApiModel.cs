using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.API.Models
{
    public class ProductApiModel
    {
        public string Slogan { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImgSource { get; set; }

        public int DiscountPercentage { get; set; }

        public Category Category { get; set; }

        public string HtmlProductDemonstration { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
