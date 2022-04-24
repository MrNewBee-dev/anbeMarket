﻿using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Anbe.Models;
using Anbe.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anbe.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AnbeContext anbeContext;

        public HomeController(AnbeContext anbeContext, SignInManager<ApplicationUser> signInManager
            , UserManager<ApplicationUser> userManager)
        {

            this.anbeContext = anbeContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = await anbeContext.Products.Where(m => m.ProductID == id).Select(x=> new ProductViewModel {
            ProductName = x.ProductName,
            Price = x.Price,
            PricetoziKonande = x.PriceToziKonande,
            Nahveyetasviye = x.NAhveyetasviye,
            IsPublish = x.IsPublish,
              NameMaqaze =  x.ApplicationUsers.NameMaqaze,
              ProductDescription = x.ProductDescription,
              ProductDetails = x.ProductDetails,
                Colors = x.ProductColors.Select(y=>y.Colors).ToList() 

            })
                .FirstOrDefaultAsync();
            
            
            if (product == null)
            {
                return NotFound();
            }

            // ReSharper disable once Mvc.ViewNotResolved
            return View(product);
        }

        public IActionResult FirstPage()
        {

            return View();
        }

        [Route("LoginUser")]
        public IActionResult Login()
        {

            return View();
        }
        [Route("LoginUser")]
        [HttpPost]

        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (Email != null && Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync(Email, Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }
            }
            return RedirectToAction("", "LoginUser");
        }

        public IActionResult Index(string pname,long? min, int? cat,int? sort)
        {
            
            
             var   list = anbeContext.Products.AsQueryable();

            if (pname != null)
            {
                

                list = list.Where(x=>x.ProductName.Contains(pname)).AsQueryable();
            }
            if (min != null)
            {
                list = list.Where(x => x.Price== min).AsQueryable();
            }
            if (cat != null)
            {
                list = list.Where(x => x.book_Categories.Any(y => y.CategoryID == cat)).AsQueryable();
            }
            if (sort !=null)
            {
                switch (sort)
                {
                    case 1:
                        list = list.OrderByDescending(x=>x.ProductID);
                            break;
                    case 2:
                        list = list.OrderBy(x => x.Price);
                        break;

                    case 3:
                        list = list.OrderByDescending(x => x.Price);
                        break;

                   
                }
            }

            var proudctlist = list.Where(x => x.ApplicationUsers.ForooshBaste != true && x.IsPublish == true &&  x.ApplicationUsers.Active == true).Select(x => new ProductViewModel
            {
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                NameMaqaze = x.ApplicationUsers.NameMaqaze,
                PricetoziKonande = x.PriceToziKonande,
                Image = (JsonConvert.DeserializeObject<List<string>>(x.ImagePath).FirstOrDefault().ToString() == null) ? "2544106a-7535-426b-8dff-88b47ebf2de9.jpg" : JsonConvert.DeserializeObject<List<string>>(x.ImagePath).FirstOrDefault().ToString()
                ,ProductId = x.ProductID

            }).ToList();
            if (!User.IsInRole("Foroshande") && !User.IsInRole("BonakDar") && !User.IsInRole("SuperAdmin"))
            {
               proudctlist = list.Where(x=>x.ApplicationUsers.ForooshBaste != true && x.IsPublish == true &&  x.ApplicationUsers.Active == true).Where(x=>x.ApplicationUsers.Roles.Where(y=>y.UserId == x.ApplicationUsersId).Select(r => r.Role.Name).FirstOrDefault() == "Foroshande").Select(x => new ProductViewModel
               {
                 ProductName = x.ProductName,
                 ProductDescription = x.ProductDescription, 
                 Price =x.Price,
                 NameMaqaze = x.ApplicationUsers.NameMaqaze,
                 PricetoziKonande = 0,
                   Image = (JsonConvert.DeserializeObject<List<string>>(x.ImagePath).FirstOrDefault().ToString() == null) ? "2544106a-7535-426b-8dff-88b47ebf2de9.jpg" : JsonConvert.DeserializeObject<List<string>>(x.ImagePath).FirstOrDefault().ToString()
                   ,ProductId =x.ProductID

               }).ToList();
            }

            return View(proudctlist);
        }
        public IActionResult Test()
        {

            return View();
        }


    }
}
