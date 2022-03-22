using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Anbe.Models;
using Anbe.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Anbe.Controllers
{
    public class RegisterSuperController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _userRole;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AnbeContext anbeContext;


        private readonly IWebHostEnvironment _env;
        public RegisterSuperController(AnbeContext anbeContext, SignInManager<ApplicationUser> signInManager
            , UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> userRole, IWebHostEnvironment env)
        {
            _userRole = userRole;
            this.anbeContext = anbeContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegiseterViewmodelss Input, IFormFile files,bool ToziKonande)
        {
            if (ModelState.IsValid )
            {
                List<string> name = new List<string>();
                name.Add("hello.jpg");
                List<Product_Category> categories = new List<Product_Category>();


                var UploadsRootFoolder = Path.Combine(_env.WebRootPath, "GalleryFiles");
                if (!Directory.Exists(UploadsRootFoolder))
                {
                    Directory.CreateDirectory(UploadsRootFoolder);
                }

                if (files != null)
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
                            name.Add(stream.Name.ToString());

                        }

                    }

                }
                var user = new ApplicationUser { UserName = Input.Telephone, Address = Input.Address, LastName = Input.FirstName, NameMaqaze = Input.NameMaqaze, FirstName = Input.FirstName, PhoneNumber = Input.Telephone,ImagePath = System.Text.Json.JsonSerializer.Serialize(name) };
                var result = await _userManager.CreateAsync(user, Input.Pass);
                if (result.Succeeded)
                {
                    string roleName = (ToziKonande) ? "BonakDar" : "Foroshande"; 

                    bool x = await _userRole.RoleExistsAsync(roleName);
                    if (!x)
                    {
                        await _userRole.CreateAsync(new ApplicationRole(roleName));
                    }
                    await _userManager.AddToRoleAsync(user, roleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
              
            }
            return View();
        }
    }
}
