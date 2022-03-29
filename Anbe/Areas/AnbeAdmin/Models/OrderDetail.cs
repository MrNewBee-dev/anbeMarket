using Anbe.Models;
using System.ComponentModel.DataAnnotations;

namespace Anbe
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Price { get; set; }


        public int ProductsProductID { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
