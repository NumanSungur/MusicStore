using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    public class AyarlarController : Controller
    {
        private readonly IUsersAdminService db;
        public AyarlarController(IUsersAdminService _db)
        {
            db = _db;
        }

        [Authorize(Roles = "Admin,Temsilci")]
        public async Task<IActionResult> Index()
        {
            return View(db.GetAll().Data);
        }

        [Authorize(Roles = "Admin")]
        [Route("/Ayarlar/Insert")]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, Route("/Ayarlar/Insert")]
        public async Task<IActionResult> Insert(UsersAdminDto data)
        {
            var DataMessage = db.Add(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("/Ayarlar/Update/{Id:int}")]
        public async Task<IActionResult> Update(int Id)
        {
            return View(db.GetById(Id).Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, Route("/Ayarlar/Update/{Id:int}")]
        public async Task<IActionResult> Update(int Id, UsersAdminDto data)
        {
            data.Id = Id;
            var DataMessage = db.Update(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View(db.GetById(Id).Data);
        }

        [Authorize(Roles = "Admin")]
        [Route("/Ayarlar/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            db.Delete(Id);
            return RedirectToAction("Index", "Ayarlar");
        }
    }
}
