using MijiKalaWebApp.Enums;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Models
{
    public class ProductAdminViewModel
    {
        public string Slogan { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImgSource { get; set; }

        public int DiscountPercentage { get; set; }

        [Required]
        public Category Category { get; set; }

        public string HtmlProductDemonstration { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
