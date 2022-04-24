using Anbe.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ViewComponentSample.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly AnbeContext _anbeContext;
        public GetMenu(AnbeContext anbeContext) => _anbeContext = anbeContext;

        public IViewComponentResult Invoke(int id = 1)
        {
            var item = _anbeContext.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            if (item !=null)
            {
                if (item.ParentCategoryID == null) return View(viewName: "GetMenu", _anbeContext.Categories.Where(x => x.ParentCategoryID == id).ToList());
                return View(viewName: "GetMenu", _anbeContext.Categories.Where(x => x.ParentCategoryID == item.ParentCategoryID).ToList());
            }


            return View(viewName: "GetMenu", item);
        }
    }
}
