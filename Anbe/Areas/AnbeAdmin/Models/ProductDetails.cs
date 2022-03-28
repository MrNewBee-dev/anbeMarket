using Anbe.Models;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class ProductDetails
    {
        [Key]
        public int ID { get; set; }
        public string Display { get; set; }
        public string Vizhegi { get; set; }
        public virtual Product Products { get; set; }
        public int ProductsProductID  { get; set; }
    }
}
