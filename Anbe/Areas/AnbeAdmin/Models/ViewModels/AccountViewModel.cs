using System.ComponentModel.DataAnnotations;

namespace Anbe.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل شما نامعتبر است.")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(100, ErrorMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور وارد شده با تکرار کلمه عبور مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }

        //[Display(Name = "نام کاربری")]
        //[Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        //public string UserName { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string FName { get; set; }
        [Display(Name = "نام خانوادگی ")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Register { get; set; }



    }

    public class RegisterAPIviewModels
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]

        //[MaxLength(11, ErrorMessage = "شماره تلفن را صحیح وارد کنید")]
        //[MinLength(11, ErrorMessage = "شماره تلفن را صحیح وارد کنید")]
        [Phone]
        public string Telephone { get; set; }

        [Required]
        //[Display(Name = "نام")]
        public string FirstName { get; set; }
        [Required]

        //[Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        [Required]

        //[Display(Name = "نام مغازه")]
        public string NameMaqaze { get; set; }
        [Required]

        //[Display(Name = "آدرس")]
        public string Address { get; set; }


        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required]
        //[MaxLength(1,ErrorMessage = "طول")]
        public byte UserType { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده نامعتبر است.")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل شما نامعتبر است.")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(100, ErrorMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور با کلمه عبور وارد شده مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

}
