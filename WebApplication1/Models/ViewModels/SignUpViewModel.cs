using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [MinLength(3,ErrorMessage = "نام شما باید بیش از ۲ حرف داشته باشد")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "نام خانوادگی شما باید بیش از ۱ حرف داشته باشد")]
        public string FamilyName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "نام کاربری شما باید بیش از ۲ حرف داشته باشد")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "رمز عبور شما باید بیش از ۶ کاراکتر داشته باشد")]
        public string PassWord { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string HomePhoneNumber { get; set; }

        [Required]
        public string MobilePhoneNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        public string Email { get; set; }

        public bool NotFirstTime { get; set; }
    }
}
