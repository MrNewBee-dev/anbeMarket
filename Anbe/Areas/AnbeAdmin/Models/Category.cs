﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anbe.Models
{
    public class Category
    {

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("category")]
        public int? ParentCategoryID { get; set; }

        public Category category { get; set; }
        public List<Category> categories { get; set; }
        public List<Product_Category> Product_Categories { get; set; }




    }
}
