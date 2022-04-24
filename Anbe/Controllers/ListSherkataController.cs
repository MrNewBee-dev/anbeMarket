using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Anbe.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Anbe.Controllers
{
    public class ListSherkataController : Controller
    {
        private readonly AnbeContext _anbeContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public ListSherkataController(AnbeContext anbeContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _anbeContext = anbeContext;
        }
        public IActionResult Index()
        {
            var NameMaqaze = _userManager.Users.Select(x => new CheckListViewModel { Id = x.Id , NameMaqaze = x.NameMaqaze }).ToList();
            return View(NameMaqaze);
        }
    }
}
