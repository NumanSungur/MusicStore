using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUsersAdminService db;
        public LoginController(IUsersAdminService _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password)
        {
            if (db.Login(Email,Password).ResultStatus== ResultStatus.Success)
            {
                var data = db.Login(Email, Password).Data;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,data.NameSurname),
                    new Claim(ClaimTypes.Role,data.Roles),
                    new Claim("Id",data.Id.ToString())
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginControl");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/Home");
            }
            else
            {
                return View();
            }           
        }
    }
}
