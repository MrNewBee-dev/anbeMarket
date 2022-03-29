using Anbe.Models;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class Product_Color
    {
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        public int ColorId { get; set; }
        public virtual Color Colors { get; set; }
    }
}
