using Anbe.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class Color
    {
        
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "کد رنگ")]
        public string EsmeRang { get; set; }
        [Required(ErrorMessage = "رنگ مورد نظر را وارد کنید")]
        [Display(Name = "کد رنگ")]
        public string HexRag { get; set; }
        
        public virtual  List<Product_Color> ProductColors { get; set; }

    }
}
