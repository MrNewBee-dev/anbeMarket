using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Areas.AnbeAdmin.Models.ViewModels;
using Anbe.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Anbe.Areas.AnbeAdmin.Controllers
{
    [Area("anbeadmin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ColorController : Controller

    {

        private readonly AnbeContext anbeContext;

        public ColorController(AnbeContext _anbeContext)
        {
            anbeContext = _anbeContext;
        }
        public IActionResult Index()
        {
            var ListColor = anbeContext.Color.ToList();
            return View(ListColor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ColorViewModels colorView)
        {
            var color = new Color { EsmeRang = colorView.EsmeRang, HexRag = colorView.HexRag };
            anbeContext.Color.Add(color);
            anbeContext.SaveChanges();


            return RedirectToAction("index");
        }
    }
}
