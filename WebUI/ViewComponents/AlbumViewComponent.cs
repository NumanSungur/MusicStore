using B.L.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.ViewComponents
{
    public class AlbumViewComponent : ViewComponent
    {
        private readonly ICategoriesService db;
        public AlbumViewComponent(ICategoriesService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAll(0).Data);
        }
    }
}
