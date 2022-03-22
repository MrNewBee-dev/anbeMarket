using System.ComponentModel.DataAnnotations;

namespace Anbe.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل شما نامعتبر است.")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }


        [Display(Name = "من را بخاطر بسپار")]
        public bool RememberMe { get; set; }

    }

}
