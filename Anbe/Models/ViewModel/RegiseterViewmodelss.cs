using System.ComponentModel.DataAnnotations;

namespace Anbe.Models.ViewModel
{
    public class RegiseterViewmodelss
    {

        [Required]
        [Display(Name = "شماره تلفن")]
        [MaxLength(11, ErrorMessage = "شماره تلفن را صحیح وارد کنید")]
        [MinLength(11, ErrorMessage = "شماره تلفن را صحیح وارد کنید")]
        [Phone(ErrorMessage = "شماره تلفن را  به درستی وارد کتید")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "نام مغازه")]
        public string NameMaqaze { get; set; }

        [Required]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        

        

        [Required]
        
        public string Pass { get; set; }

    }
}
