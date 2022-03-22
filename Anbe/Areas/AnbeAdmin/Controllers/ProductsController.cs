using Anbe.Data;
using Anbe.Models;
using Anbe.Models.ViewModels;
using BookShop.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nazar1988.Areas.MyMaster.Controllers
{
    [Area("AnbeAdmin")]
    [Authorize(Roles = "Foroshande,BonakDar,SuperAdmin")]
    public class ProductsController : Controller
    {
        //public async Task<IActionResult> Edit(int id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    else {

        //        var productid = _context.Products.FindAsync(id);
        //        if (productid == null)
        //        {
        //            return NotFound();
        //        }
        //        else { 

        //        }
        //    }

        //} 
        private readonly AnbeContext _context;
        private readonly BooksRepository _repository;
        [Obsolete]
        private readonly IWebHostEnvironment _env;
        public ProductsController(AnbeContext context, BooksRepository repository, IWebHostEnvironment env)
        {
            _context = context;
            _repository = repository;
            _env = env;

        }

        // GET: MyMaster/Products
        public async Task<IActionResult> Index(string pname,string Msg, int pageIndex = 1 )
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.numPage = (pageIndex - 1) * 10 + 1;
            var updateuser = await _context.Users.Where(x => x.Id == userid).FirstOrDefaultAsync();
            if (updateuser == null)
            {
                return Content("کاربر یافت نشد");
            }
            ViewBag.Forosh = updateuser.ForooshBaste;
            if (Msg != null)
            {
                ViewBag.Msg = "در ثبت اطلاعات خطایی رخ داده است لطفا مجددا تلاش کنید !!!";
            }
            if (User.IsInRole("SuperAdmin"))
            {

                var model = await _context.Products.ToListAsync();
                if (pname != null)
                {
                    model =  model.Where(p => p.ProductName.Contains(pname,StringComparison.OrdinalIgnoreCase) ).ToList();
                }
              var  pagingModel = PagingList.Create(model, 10, pageIndex);
                pagingModel.RouteValue = new RouteValueDictionary {
                    { "row",10 },
                    { "pname",pname }
                };
              
                return View(pagingModel);
            }
            if (pname == null)
            {
                var pagingModel = PagingList.Create(await _context.Products.Where(x=>x.ApplicationUsersId == updateuser.Id).ToListAsync(), 10, pageIndex);
                pagingModel.RouteValue = new RouteValueDictionary {
                    { "row",10 },
                    { "pname",pname }
                };
                return View(pagingModel);
            }
          
            var pagingModel1 = PagingList.Create(await _context.Products.Where(p => p.ProductName.Contains(pname, StringComparison.OrdinalIgnoreCase) && p.ApplicationUsersId == updateuser.Id).ToListAsync(), 10, pageIndex);


            pagingModel1.RouteValue = new RouteValueDictionary {
                    { "row",10 },
                    { "pname",pname }
                };

            

            return View(pagingModel1);

        }

        // GET: MyMaster/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            // ReSharper disable once Mvc.ViewNotResolved
            return View(product);
        }
        
        public async Task<IActionResult> QickEdit(string productName, string Price, string priceTozi, int? id, int pageIndex = 1)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateuser = await _context.Users.Where(x => x.Id == userid).FirstOrDefaultAsync();
            if (updateuser == null)
            {
                return Content("کاربر یافت نشد");
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
             Price = Price.Replace(",", "").Replace("تومان","");
            priceTozi = priceTozi.Replace(",", "").Replace("تومان", "");
            product.ProductName = productName;
            product.Price = Int32.Parse(Price);
            product.PriceToziKonande = Int32.Parse(priceTozi); 
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", new { pageIndex = pageIndex });
        }

            public async Task<IActionResult> EditProductView(int? id, int pageIndex = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsPublish = !product.IsPublish;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", new { pageIndex = pageIndex });

        }
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }

        public async Task<IActionResult> End()
        {

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateuser = await _context.Users.Where(x => x.Id == userid).FirstOrDefaultAsync();
            if (updateuser == null)
            {
                return Content("کاربر یافت نشد");
            }
            else
            {
                if (updateuser.ForooshBaste)
                {
                    updateuser.ForooshBaste = false;
                }
                else
                {
                    updateuser.ForooshBaste = true;
                }

                _context.Users.Update(updateuser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");
        }
        // GET: MyMaster/Products/Create
        [HttpGet]
        public IActionResult Create()
        {

            var viewModel = new ProductViewModel(_repository.GetAllCategories());
            return View(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
       


        // POST: MyMaster/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel viewModel, IFormFile files)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateuser = await _context.Users.Where(x => x.Id == userid).FirstOrDefaultAsync();
            if (updateuser == null)
            {
                return Content("کاربر یافت نشد");
            }



            if (ModelState.IsValid && userid != null)
            {
                List<string> name = new List<string>();
                name.Add("logo.png");
                List<Product_Category> categories = new List<Product_Category>();


                var UploadsRootFoolder = Path.Combine(_env.WebRootPath, "GalleryFiles");
                if (!Directory.Exists(UploadsRootFoolder))
                {
                    Directory.CreateDirectory(UploadsRootFoolder);
                }
              
                    if (files  != null)
                    {
                    name.Clear();
                        string FileExtention = Path.GetExtension(files.FileName);

                        if (FileExtention == ".jpg" || FileExtention == ".png")
                        {


                            string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtention);
                            var path = Path.Combine(UploadsRootFoolder, NewFileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {

                                await files.CopyToAsync(stream);
                                name.Add(NewFileName);

                            }

                        }

                    }




                

                var Transaction = _context.Database.BeginTransaction();
                try
                {
                    Product product = new Product()
                    {
                        ProductName = viewModel.ProductName,
                        Price = viewModel.Price,
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
                        ,ApplicationUsersId = updateuser.Id


                    };
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();



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

                        await _context.Product_Categories.AddRangeAsync(categories);
                    }

                    await _context.SaveChangesAsync();
                    Transaction.Commit();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index", new { Msg = "Failed" });
                }
            }
            else
            {
                viewModel.Categories = _repository.GetAllCategories();
                return View(viewModel);
            }
        }
        public async Task<IActionResult> Edit(ProductEditViewModelViews viewModel)
        {

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && userid != null)
            {
                var ProductFound = await _context.Products.FindAsync(viewModel.ProductId);
                if (ProductFound == null)
                {
                    return NotFound();
                }
                ProductFound.IsPublish = viewModel.IsPublish;
                ProductFound.Price = viewModel.Price;
                ProductFound.PriceToziKonande = viewModel.PricetoziKonande;
                ProductFound.ProductDescription = viewModel.ProductDescription;
                ProductFound.ProductName = viewModel.ProductName;
                ProductFound.ProductNumber = viewModel.ProductNumber;
                ProductFound.ProductTotal = viewModel.ProductTotal;
                ProductFound.IsPublish = viewModel.IsPublish;

                _context.Products.Update(ProductFound);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");
        }
        [Route("Upload")]
        public IActionResult FileUploader(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> FileUploader(IEnumerable<IFormFile> files, int id)
        {
            List<string> name = new List<string>();
            var products = _context.Products.Find(id);

            if (products == null)
            {
                return NotFound();
            }

            var UploadsRootFoolder = Path.Combine(_env.WebRootPath, "GalleryFiles");
            if (!Directory.Exists(UploadsRootFoolder))
            {
                Directory.CreateDirectory(UploadsRootFoolder);
            }
            foreach (var item in files)
            {
                if (files != null)
                {
                    string FileExtention = Path.GetExtension(item.FileName);

                    if (FileExtention == ".jpg" || FileExtention == ".png")
                    {


                        string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtention);
                        var path = Path.Combine(UploadsRootFoolder, NewFileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {

                            await item.CopyToAsync(stream);
                            name.Add(stream.Name.ToString());

                        }

                    }

                }
            }

            products.ImagePath = System.Text.Json.JsonSerializer.Serialize(name);
            //   var show = System.Text.Json.JsonSerializer.Deserialize<string>(products.ImagePath);

            try
            {
                _context.Update(products);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();

            }

            return new JsonResult("success");

        }
    }



}

