using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Anbe.Models;
using Anbe.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ZarinpalSandbox;

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
                        list = list.OrderByDescending(x=>x.CreateDate);
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

        public IActionResult OnlinePayment(int id)
        {


            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();

            



                var payment = new Payment(10000);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {

                    var product = anbeContext.Products.Where(x => x.ProductID == id).FirstOrDefault();
                    product.CreateDate = DateTime.Now;
                    anbeContext.Products.Update(product);
                    anbeContext.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "مشکلی در پرداخت رخداده است.";
                return View();

            }

            return NotFound();
        }

        public IActionResult OnlinePaymentSharge(int id)
        {


            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();





                var payment = new Payment(id);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {

                    var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var UserFound = anbeContext.Users.SingleOrDefault(x => x.Id == UserId);
                    if (UserFound == null)
                    {
                        return NotFound();
                    }
                    
                    UserFound.LastVisitDateTime = DateTime.Now.AddMonths(1); 
                    anbeContext.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "مشکلی در پرداخت رخداده است.";
                return View();

            }

            return NotFound();
        }




        public async Task<IActionResult> OnlinePaymentWallet(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();

                var order = anbeContext.wallets.Find(id);
                if (order == null)
                {
                    return NotFound();
                }



                var payment = new Payment(order.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsPay = true;
                    //Product product;                    
                    anbeContext.wallets.Update(order);
                    //foreach (var item in details)
                    //{
                    //    product = _context.Products.FirstOrDefault(x => x.ProductID == item.ProductId);
                    //    product.ProductTotal -= item.Count;
                    //    _context.Update(product);
                    //}

                    await anbeContext.SaveChangesAsync();
                    ViewBag.code = res.RefId;
                    return View();
                }

            }

            return NotFound();
        }
        public IActionResult Test()
        {

            return View();
        }


    }
}
