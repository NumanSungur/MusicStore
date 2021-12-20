using B.L.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.ViewComponents
{
    public class ProductSecondViewComponent : ViewComponent
    {
        private readonly IProductsService db;
        public ProductSecondViewComponent(IProductsService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAllSecond());
        }
    }
}
