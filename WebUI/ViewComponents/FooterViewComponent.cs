using B.L.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IProductsService db;
        public FooterViewComponent(IProductsService _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.GetAllFooter());
        }

    }
}
