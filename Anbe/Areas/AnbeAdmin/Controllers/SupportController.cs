using Microsoft.AspNetCore.Mvc;

namespace Anbe.Areas.AnbeAdmin.Controllers
{
    [Area("anbeadmin")]
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
