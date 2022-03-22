using System.ComponentModel.DataAnnotations;

namespace Anbe.Models.ViewModels
{

    public class RolesViewModel
    {
        public string RoleID { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string RoleName { get; set; }


    }

}
