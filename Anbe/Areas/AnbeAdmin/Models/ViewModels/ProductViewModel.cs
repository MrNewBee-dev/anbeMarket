﻿using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Areas.AnbeAdmin.Models.ViewModels;
using Anbe.Areas.Identity.Data;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anbe.Models.ViewModels
{

    public class ProductReportViewModel {

        
        public string PricetoziKonande { get; set; }
        public string Granty { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string NameMaqaze { get; set; }
        public string ProductCategoryName { get; set; }
          public string Colors { get; set; }

    }
    public class ProductViewModel
    {
        public ProductViewModel(BooksSubCategoriesViewModel _SubCategoriesVM)
        {
            SubCategoriesVM = _SubCategoriesVM;
        }


        public ProductViewModel()
        {

        }

        public BooksSubCategoriesViewModel SubCategoriesVM { get; set; }
        public IEnumerable<TreeViewCategory> Categories { get; set; }
        
        
        public int ProductId { get; set; }
        [Display(Name = "نامحصول")]
        public string ProductName { get; set; }
        [Display(Name = "کد محصول")]
        public int ProductNumber { get; set; }//code mahsol
        [Display(Name = "تعداد محصول")]
        public int ProductTotal { get; set; }//tedad kole mahsolat
        [Display(Name = "تعداد فروخته شده ")]
        public int? ProductSold { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime? CreateDate { get; set; }//roze ijad mahsool
        [Display(Name = "منتشر شده")]
        public bool IsPublish { get; set; }

        [Display(Name = "تسویه دار")]
        public bool Nahveyetasviye { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "قیمت برای توزیع کننده")]
        public int PricetoziKonande { get; set; }


        [Display(Name = "شرح محصول")]
        public string ProductDescription { get; set; }

        public string ProductUrl { get; set; }

        [Display(Name = "نوع دسته ")]
        public int[] CategoryId { get; set; }

        public string NameMaqaze { get; set; }

        public IFormFile FilesName { get; set; }

       public List<string> DisplayName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "رنگ‌ها")]
        public string ColorId { get; set; }

        public List<string> Value { get; set; }

        [Display(Name = "عکس محصول")]
        public string Image { get; set; }
     //   public virtual List<Color> Colors { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
        public List<Color> Colors { get; set; }

    }
    public class CheckListViewModel
    {
        public string NameMaqaze { get; set; }
        public string Id { get; set; }

    }

        public class ProductViewModelE
    {
        public ProductViewModelE(BooksSubCategoriesViewModel _SubCategoriesVM)
        {
            SubCategoriesVM = _SubCategoriesVM;
        }


        public ProductViewModelE()
        {

        }
        
        
        public int[] ColorId { get; set; }
        //public string[] ColorIdies { get; set; }

        public BooksSubCategoriesViewModel SubCategoriesVM { get; set; }
        public IEnumerable<TreeViewCategory> Categories { get; set; }
        
        public List<Color> Colors { get; set; }

        [Required]

        public int ProductId { get; set; }
        
        [Display(Name = "نامحصول")]
        public string ProductName { get; set; }
        
        [Display(Name = "کد محصول")]
        public int ProductNumber { get; set; }//code mahsol
        [Display(Name = "تعداد محصول")]
        public int ProductTotal { get; set; }//tedad kole mahsolat
        [Display(Name = "تعداد فروخته شده ")]
        public int? ProductSold { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime? CreateDate { get; set; }//roze ijad mahsool
        [Display(Name = "منتشر شده")]
        public bool IsPublish { get; set; }

        [Display(Name = "تسویه دار")]
        public bool Nahveyetasviye { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "قیمت برای توزیع کننده")]
        public int PricetoziKonande { get; set; }


        [Display(Name = "شرح محصول")]
        public string ProductDescription { get; set; }

        public string ProductUrl { get; set; }

        [Display(Name = "نوع دسته ")]
        public int[] CategoryId { get; set; }

        public string NameMaqaze { get; set; }

        public IFormFile FilesName { get; set; }

        public List<string> DisplayName { get; set; }

        public List<string> Value { get; set; }

        [Display(Name = "عکس محصول")]
        public string Image { get; set; }
        //public virtual List<Color> Colors { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }

    }
    public class BooksSubCategoriesViewModel
    {
        public BooksSubCategoriesViewModel(List<TreeViewCategory> _Categories, int[] _CategoryID)
        {
            Categories = _Categories;
            CategoryID = _CategoryID;
        }

        public List<TreeViewCategory> Categories { get; set; }
        public int[] CategoryID { get; set; }
    }

    public class ProductViewModelViews
    {
        [Required]
        public bool NAhveyetasviye { get; set; }
        [Required]
        public string ProductName { get; set; }


        public string CompanyName { get; set; }

        public string UserRole { get; set; }

        public int Id { get; set; }

        public int ProductNumber { get; set; }//code mahsol
        public int ProductTotal { get; set; }//tedad kole mahsolat
        public int? ProductSold { get; set; }
        public DateTime? CreateDate { get; set; }//roze ijad mahsool
        public bool IsPublish { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int PriceToziKonande { get; set; }
        [Required]
        public string ProductDescription { get; set; }



        public string ProductUrl { get; set; }

        public Discount DiscountId { get; set; }

        public List<string> ImagePath { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUsersId { get; set; }
        [Required]
        public List<Product_Category> ProductCategories { get; set; }
        public List<CategoryView> Categories { get; set; }
        [Required]
        public virtual ICollection<ProductDescriptionViewModelViews> ProductDetails { get; set; }
        [Required]
        public virtual List<ColorViewModels> Colors { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

    }

    public class ProductDescriptionViewModelViews
    {
        public string Display { get; set; }
        public string Vizhegi { get; set; }
    }


    public class ProductEditViewModelViews
    {
        [Required(ErrorMessage = "نام محصول را وارد کنید")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "توضیحات محصول را وارد کنید")]
        public string ProductDescription { get; set; }




        public int ProductNumber { get; set; }//code mahsol

        public int ProductTotal { get; set; }//tedad kole mahsolat


        public bool Nahveyetasviye { get; set; }

        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "قیمت محصول را وارد کنید")]
        public int Price { get; set; }

        [Required(ErrorMessage = "قیمت محصول را وارد کنید")]
        public int PricetoziKonande { get; set; }

        public int ProductId  { get; set; }

        public IFormFile files { get; set; }
    }
}
