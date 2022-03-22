using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ViewComponentSample.ViewComponents
{
    public class GetProfile : ViewComponent
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        public GetProfile(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task <IViewComponentResult> InvokeAsync() {
        
            var name = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           var listName= await _userManager.FindByIdAsync(name);
            var list = new GetProfileViewModel { Name = listName.FirstName };
            return View("GetProfile" , list); 
        
        
        
        }
    }
    class GetProfileViewModel {

        public string Name { get; set; }
    }
}
