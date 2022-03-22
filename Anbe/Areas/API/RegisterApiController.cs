using Anbe.Areas.Api.Classes;
using Anbe.Areas.API.Service;
using Anbe.Areas.Identity.Data;
using Anbe.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anbe.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterApiController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly RoleManager<ApplicationRole> _userRole;

        public RegisterApiController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> userRole, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userManager = userManager;
            _userRole = userRole;
        }

        [AllowAnonymous]
        // POST api/<RegisterApiController>
        [HttpPost]
        public async Task<string> Post([FromBody] RegisterAPIviewModels Input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Address = Input.Address, LastName = Input.LastName, NameMaqaze = Input.NameMaqaze, FirstName = Input.FirstName, PhoneNumber = Input.Telephone };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    var userRole = await _userRole.RoleExistsAsync("BonakDar");
                    var userRole2 = await _userRole.RoleExistsAsync("Foroshande");
                    var userRole3 = await _userRole.RoleExistsAsync("MardomAdi");

                    if (!userRole || !userRole2 || !userRole3)
                    {
                        await _userRole.CreateAsync(new ApplicationRole("BonakDar"));
                        await _userRole.CreateAsync(new ApplicationRole("Foroshande"));
                        await _userRole.CreateAsync(new ApplicationRole("MardomAdi"));
                    }

                    switch (Input.UserType)
                    {
                        case 0:
                            await _userManager.AddToRoleAsync(user, "BonakDar");
                            break;
                        case 1:
                            await _userManager.AddToRoleAsync(user, "Foroshande");
                            break;
                        default:
                            await _userManager.AddToRoleAsync(user, "MardomAdi");
                            break;
                    }

                    await _signInManager.SignInAsync(user, isPersistent: true);

                    return "Registered";
                }

            }

            return "error";

        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        //[HttpPost]
        public virtual async Task<ApiResult<string>> SignIn([FromBody] SignInViewModel ViewModel)
        {
            var User = await _userManager.FindByNameAsync(ViewModel.Email);
            if (User == null)
                return BadRequest("نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
            else
            {
                var result = await _userManager.CheckPasswordAsync(User, ViewModel.Password);
                if (result)
                    return Ok(await _jwtService.GenerateTokenAsync(User));
                else
                    return BadRequest("نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
            }

        }
    }
}
