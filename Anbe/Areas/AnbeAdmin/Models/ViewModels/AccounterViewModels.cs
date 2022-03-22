using System;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Models.ViewModels
{
    public class AccounterViewModels
    {
        [Display(Name = "تاریخ صدور")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "مجموع قیمت")]
        public int SumPrice { get; set; }

        [Display(Name = "تایید حسابداری")]
        public int Marhale { get; set; }

        public string id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


    }
}
