using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models.ViewModels
{
    public class ColorViewModels
    {
        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "رنگ")]
        public string EsmeRang { get; set; }

        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "کد رنگ")]
        public string HexRag { get; set; }

        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "کد رنگ")]
        public int Id { get; set; }


    }
}
