using Anbe.Areas.AnbeAdmin.Models.ViewModels;
using Anbe.Data;
using Anbe.Models;
using Anbe.Models.ViewModels;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anbe.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductApisAppController : ControllerBase
    {
        private readonly AnbeContext _anbeContext;

        public ProductApisAppController(AnbeContext anbeContext)
        {
            _anbeContext = anbeContext;
        }
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        //        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Foroshande,BonakDar")]

        public async Task<ActionResult> Get(int id = 0)
        {
            var list = await _anbeContext.Products.Where(f => f.ApplicationUsers.ForooshBaste == false).Select(x => new ProductViewModelViews
            {

                Id = x.ProductID,
                ProductName = x.ProductName,
                ImagePath = JsonConvert.DeserializeObject<List<string>>(x.ImagePath),
                CreateDate = x.CreateDate,
                Colors = x.Colors.Select(tc => new ColorViewModels { EsmeRang = tc.EsmeRang, HexRag = tc.HexRag }).ToList(),

                CompanyName = x.ApplicationUsers.NameMaqaze
                ,
                UserRole = (x.ApplicationUsers.Roles.Where(y => y.UserId == x.ApplicationUsers.Id).Select(r => r.Role.Name).FirstOrDefault() == "BonakDar" ? "بنکدار" : " فروشنده"),

                Price = x.Price,
                PriceToziKonande = x.PriceToziKonande
                ,
                ProductDescription = x.ProductDescription,
                ProductDetails = x.ProductDetails.Select(tc => new ProductDescriptionViewModelViews() { Display = tc.Display, Vizhegi = tc.Vizhegi }).ToList()
                ,
                Categories = x.book_Categories.Where(y => y.ProductID == x.ProductID).Select(t => new CategoryView() { CategoryName = t.Category.CategoryName }).ToList()

            }).OrderByDescending(x => x.Id).Skip(10 * id).Take(10).ToListAsync();





            return new JsonResult(list);

        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Foroshande,BonakDar")]
        public async Task<ActionResult> EndProduct()
        {
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateuser = await _anbeContext.Users.Where(x => x.Id == userid).FirstOrDefaultAsync();
            if (updateuser == null)
            {
                return Content("کاربر یافت نشد");
            }
            else
            {
                updateuser.ForooshBaste = !updateuser.ForooshBaste;

                _anbeContext.Users.Update(updateuser);
                await _anbeContext.SaveChangesAsync();
            }

            return new JsonResult("User Not found");
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Foroshande,BonakDar,SuperAdmin")]
        public async Task<ActionResult> EditProductView(bool PatientId = false , int idName = 1)
        {
            var findName = await _anbeContext.Products.FindAsync(idName);
            if (findName != null)
            {
                findName.IsPublish = PatientId;
                _anbeContext.Products.Update(findName);
                await _anbeContext.SaveChangesAsync();
            }
            return Ok();
        }
            // POST api/<ValuesController>

            [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Foroshande,BonakDar")]
        public async Task<ActionResult> AddProduct([FromBody] ProductViewModel viewModel)
        {

            if (HttpContext.User.Identity != null)
            {
                if (ModelState.IsValid)
                {
                    List<string> name = new List<string>();
                    name.Add("hello.jpg");
                    List<Product_Category> categories = new List<Product_Category>();

                    var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var Transaction = await _anbeContext.Database.BeginTransactionAsync();
                    try
                    {
                        Product product = new Product()
                        {
                            ProductName = viewModel.ProductName,
                            Price = viewModel.Price,
                            Colors = viewModel.Colors,
                            ProductDetails = viewModel.ProductDetails,
                            ApplicationUsersId = user,
                            PriceToziKonande = viewModel.PricetoziKonande,
                            ProductDescription = viewModel.ProductDescription,
                            CreateDate = DateTime.Now,
                            ProductNumber = viewModel.ProductNumber,
                            ProductTotal = viewModel.ProductTotal,
                            IsPublish = viewModel.IsPublish,
                            NAhveyetasviye = viewModel.Nahveyetasviye,
                            ImagePath = System.Text.Json.JsonSerializer.Serialize(name),
                            DiscountId = new Discount
                            {
                                DiscountPercent = 0,
                                EndtDate = DateTime.Now,
                                StartDate = DateTime.Now
                            }


                        };
                        await _anbeContext.Products.AddAsync(product);
                        await _anbeContext.SaveChangesAsync();



                        if (viewModel.CategoryId != null)
                        {
                            for (int i = 0; i < viewModel.CategoryId.Length; i++)
                            {
                                Product_Category category = new Product_Category()
                                {
                                    ProductID = product.ProductID,
                                    CategoryID = viewModel.CategoryId[i],
                                };

                                categories.Add(category);
                            }

                            await _anbeContext.Product_Categories.AddRangeAsync(categories);
                        }

                        await _anbeContext.SaveChangesAsync();
                        await Transaction.CommitAsync();
                        return new JsonResult("Add Successfully");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("not found");
                    }
                }
            }
            return new JsonResult("User Not found");
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Foroshande,BonakDar")]
        public async Task<ActionResult> Put(int id, [FromBody] Product viewModel)
        {

            if (HttpContext.User.Identity != null)
            {
                var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (ModelState.IsValid && user != null)
                {
                    var ProductFound = await _anbeContext.Products.FindAsync(id);
                    if (ProductFound == null)
                    {
                        return NotFound();
                    }

                    ProductFound.IsPublish = viewModel.IsPublish;
                    ProductFound.Price = viewModel.Price;
                    ProductFound.PriceToziKonande = viewModel.PriceToziKonande;
                    ProductFound.ProductDescription = viewModel.ProductDescription;
                    ProductFound.ProductName = viewModel.ProductName;
                    ProductFound.ProductNumber = viewModel.ProductNumber;
                    ProductFound.ProductTotal = viewModel.ProductTotal;
                    ProductFound.IsPublish = viewModel.IsPublish;

                    _anbeContext.Products.Update(ProductFound);
                    await _anbeContext.SaveChangesAsync();
                    return new JsonResult("ثبت با موفقیت انجام شد");
                }


            }
            return new JsonResult("User Not found");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
