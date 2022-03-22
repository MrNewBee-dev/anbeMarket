using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class DastebandiKolli
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم صنف")]
        public string Name { get; set; }

        public virtual List<JadvaleVaset> Users { get; set; }
    }

}
