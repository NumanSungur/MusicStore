using B.L.Abstract;
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
    public class BasketController : Controller
    {
        private readonly ITempBasketsService sepet;
        public BasketController(ITempBasketsService _sepet)
        {
            sepet = _sepet;  
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SepetDelete(int ID)
        {
            sepet.Delete(ID);
            return Json("");
        }
        public JsonResult JSONStokAyari(int ID, int Durum)
        {
            return Json(sepet.SepetArttırEksilt(ID, (Durum == 0) ? false : true));
        }
        public IActionResult PartialSepetGet()
        {
            int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
            return PartialView("/Views/PartialView/_PartialViewSepet.cshtml", sepet.GetAll(Cookie).Data);
        }
        public JsonResult DetailSepetInsert(int ID, int varyant)
        {
            string Mesaj = "";
            if (Request.Cookies["SepetId"] == null)
            {                
                int Bulunan = sepet.GetByIdAuto(1).Data.Uretilen + 1;
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(6);
                Response.Cookies.Append("SepetId", Bulunan.ToString(), cookie);

                AutoBasketDto dto = sepet.GetByIdAuto(1).Data;
                dto.Uretilen++;
                sepet.AutoBasketUpdate(dto);                

                Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Bulunan, varyant).Message;
            }
            else
            {
                int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
                Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Cookie, varyant).Message;
            }

            return Json(Mesaj);
        }
    }
}
