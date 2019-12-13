using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        [StringLength(50,MinimumLength =3, ErrorMessage = "نام کاربری شما باید بیش از ۲ حرف داشته باشد")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength =7, ErrorMessage = "رمز عبور شما باید بیش از ۶ کاراکتر داشته باشد")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }

        public bool NotFirstTime { get; set; }
    }
}
