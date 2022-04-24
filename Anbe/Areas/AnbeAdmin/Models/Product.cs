using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anbe.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public bool NAhveyetasviye { get; set; }
        public string ProductName { get; set; }
        public int ProductNumber { get; set; }//code mahsol
        public int ProductTotal { get; set; }//tedad kole mahsolat
        public int? ProductSold { get; set; }
        public DateTime? CreateDate { get; set; }//roze ijad mahsool
        public bool IsPublish { get; set; }
        public int Price { get; set; }
        public int PriceToziKonande { get; set; }
        public string ProductDescription { get; set; }

        public virtual List<Product_Color> ProductColors { get; set; }

        public string ProductUrl { get; set; }
        public string Granty { get; set; }


        public Discount DiscountId { get; set; }

        public string ImagePath { get; set; }




        [Column(TypeName = "nvarchar(450)")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUsersId { get; set; }

        
        public List<Product_Category> book_Categories { get; set; }
        
        
        
        public List<OrderDetail> OrderDetails { get; set; }

        
        [ForeignKey("ProductsProductID")]
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }

    //    public virtual ICollection<Color> Colors { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

    }
}
