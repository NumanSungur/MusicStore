using B.L.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoriesService db;
        public CategoryViewComponent(ICategoriesService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAll(0).Data);
        }
    }
}
