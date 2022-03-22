using Anbe.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class JadvaleVaset
    {
        [MaxLength(450)]
        public string UserId { get; set; }

        public virtual ApplicationUser Useree { get; set; }

        public int DastebandiKolliId { get; set; }

        public virtual DastebandiKolli DastebandiKolliee { get; set; }


    }
}
