using B.L.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductsService db;
        public ProductViewComponent(IProductsService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAllFirst());
        }

    }
}
