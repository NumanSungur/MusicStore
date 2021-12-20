using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProductsService service;
        private readonly ITempBasketsService sepet;
        private readonly IVariantsService variantdb;        
        public HomeController(IProductsService _service, ITempBasketsService _sepet, IVariantsService _variantdb)
        {
            service = _service;
            sepet = _sepet;
            variantdb = _variantdb;
            
        }
        public IActionResult Index()
        {
            
           return View(service.GetAll());
        }
        public IActionResult Album()
        {            
            return View(service.GetAll());
        }       
        public IActionResult Contact()
        {
            return View();
        }
        public JsonResult SepetEkle(string ID)
        {
            string Mesaj = "";
            if (variantdb.GetAll(int.Parse(ID)).Data != null)
            {
                Mesaj = "Bu Ürüne Ait varyasyonlar olduğu için detay sayfasından seçim yaparak ekleyebilirsiniz.";
            }
            else
            {
                if (Request.Cookies["SepetId"] == null)
                {                    
                    int Bulunan = sepet.GetByIdAuto(1).Data.Uretilen + 1; 
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(6);
                    Response.Cookies.Append("SepetId", Bulunan.ToString(), cookie);
                   
                    AutoBasketDto dto = sepet.GetByIdAuto(1).Data;
                    dto.Uretilen++;
                    sepet.AutoBasketUpdate(dto);
                    
                    Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Bulunan, 0).Message;
                }
                else
                {
                    int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
                    Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Cookie, 0).Message;
                }
            }
            return Json(Mesaj);
        }
    }
}
