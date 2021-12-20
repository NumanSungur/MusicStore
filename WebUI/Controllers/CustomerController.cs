using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService db;
        private readonly IOrderDetailsService details;
        private readonly IOrdersService orders;
        public CustomerController(ICustomersService _db, IOrderDetailsService _details, IOrdersService _orders)
        {
            db = _db;
            details = _details;
            orders = _orders;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string KullaniciAdi, string KullaniciSifre)
        {
            bool sonuc = (KullaniciAdi.Contains("@") ? true : false);
            if (sonuc)
            {
                if (db.Login(KullaniciAdi, null, KullaniciSifre).ResultStatus == ResultStatus.Success)
                {
                    var data = db.Login(KullaniciAdi, null, KullaniciSifre);
                    var claims = new List<Claim>
                    {
                    new Claim("ID",data.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,data.Data.NameSurname),
                    };
                    var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                    ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                    var CookiesSüresi = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(120),
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(principal, CookiesSüresi);
                    return Redirect("/");
                }
                else
                {
                    TempData["Error"] = "Giriş Başarısız, Lütfen Tekrar Deneyiniz...";
                    return View();
                }
            }
            else
            {
                if (db.Login(null, KullaniciAdi, KullaniciSifre).ResultStatus == ResultStatus.Success)
                {
                    var data = db.Login(null, KullaniciAdi, KullaniciSifre);
                    var claims = new List<Claim>
                    {
                    new Claim("ID",data.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,data.Data.NameSurname),
                    };
                    var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                    ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                    var CookiesSüresi = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(120),
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(principal, CookiesSüresi);
                    return Redirect("/");
                }
                else
                {
                    TempData["Error"] = "Giriş Başarısız, Lütfen Tekrar Deneyiniz...";
                    return View();
                }
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(CustomersUpdateDto data)
        {
            if (Request.Form["Advert"] == "on")
            {
                data.Advert = true;
            }
            data.Gender = true;
            if (db.Add(data).ResultStatus == ResultStatus.Success)
            {
                CustomersDto uye = db.Login(data.Email, data.Phone, data.Password).Data;
                var claims = new List<Claim>
                {
                    new Claim("ID",uye.Id.ToString()),
                    new Claim(ClaimTypes.Name,uye.NameSurname),
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                var CookiesSüresi = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(120), 
                    IsPersistent = true                         
                };
                await HttpContext.SignInAsync(principal, CookiesSüresi);
                return Redirect("/");
            }
            else
            {
                TempData["Error"] = "Kayıt Başarısız, Lütfen Tekrar Deneyiniz...";
                return View("Login");
            }
        }
        public IActionResult Hesabım()
        {
            int BulunanUyeId = int.Parse(User.FindFirst(x => x.Type == "ID").Value.ToString());            
            return View(db.GetById(BulunanUyeId).Data);
        }
        [HttpPost]
        public async Task<IActionResult> Hesabım(CustomersUpdateDto data)
        {
            int BulunanUyeId = int.Parse(User.FindFirst(x => x.Type == "ID").Value.ToString());
            data.Id = BulunanUyeId;
            
            var DataMessage = db.Update(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View(db.GetById(BulunanUyeId).Data);
        }
        public IActionResult Siparişlerim(int Id)
        {
            return View(orders.GetAll(null).Data);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Login");
        }
    }
}
