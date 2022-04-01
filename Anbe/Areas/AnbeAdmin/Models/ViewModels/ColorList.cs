using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models.ViewModels
{
    public class ColorList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "کد رنگ")]
        public string EsmeRang { get; set; }
    }
}
