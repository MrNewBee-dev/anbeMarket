using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;

namespace Anbe.Areas.AnbeAdmin.Controllers
{
    [Area("AnbeAdmin")]
    [Authorize(Roles = "SuperAdmin")]
    public class DasteBandiKolliController : Controller
    {
        private readonly AnbeContext anbeContext;
        public DasteBandiKolliController(AnbeContext _anbeContext)
        {
            anbeContext = _anbeContext;
        }
        public async Task<IActionResult> Index(string Msg, int page = 1)
        {
            if (Msg != null)
            {
                ViewBag.Msg = "در ثبت اطلاعات خطایی رخ داده است لطفا مجددا تلاش کنید !!!";
            }
            var pagingModel = PagingList.Create(await anbeContext.DastebandiKollis.ToListAsync(), 8, page);
            return View(pagingModel);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(DastebandiKolli dastebandi)
        {
            var test = anbeContext.Add(dastebandi);
            await anbeContext.SaveChangesAsync();
            return RedirectToAction("index");

        }
    }
}
