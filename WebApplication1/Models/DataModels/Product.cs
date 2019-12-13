using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MijiKalaWebApp.Enums;

namespace MijiKalaWebApp.Models.DataModels
{
    
    public class Product
    {
        public Product()
        {
            ProductId = new Guid();
        }
        public Guid ProductId { get; set; }

        public string Slogan { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImgSource { get; set; }

        public int DiscountPercentage { get; set; }
        
        public Category Category { get; set; }

        public string HtmlProductDemonstration { get; set; }

        public List<Comment> Comments { get; set; }

        public DateTime ReleaseDate { get; set; }

    }
}
