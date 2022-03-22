using Anbe.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ViewComponentSample.ViewComponents
{
    public class MenuSub : ViewComponent
    {
        private readonly AnbeContext _anbeContext;
        public MenuSub(AnbeContext anbeContext) => _anbeContext = anbeContext;

        public IViewComponentResult Invoke()
        {
            var item = _anbeContext.Categories.Where(x => x.ParentCategoryID == null).ToList();
            return View(viewName: "MenuSub", item);
        }
    }
}
