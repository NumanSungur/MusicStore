using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesService db;
        public CategoryController(ICategoriesService _db)
        {
            db = _db;
        }
        [Route("/Category/{Id:int?}")]
        public async Task<IActionResult> Index(int? Id)
        {
            if (Id == null)
            {
                return View(db.GetAll(0).Data);
            }
            else
            {
                TempData["Category"] = db.GetByIdFirst(Convert.ToInt32(Id)).Data.Name;
                return View(db.GetAll(Convert.ToInt32(Id)).Data);
            }          
        }
        [Route("/Category/Insert/{Id:int?}")]
        public async Task<IActionResult> Insert(int Id)
        {
            return View();
        }
        [HttpPost,Route("/Category/Insert/{Id:int?}")]
        public async Task<IActionResult> Insert(int Id, CategoriesDto data)
        {
            if (Id != null)
            {
                data.ParentId = Id;
                data.Id = 0;
            }
            else
            {
                data.ParentId = 0;
            }
            var DataMessage = db.Add(data);
            if (DataMessage.ResultStatus== ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View();
        }
        [Route("/Category/Update/{Id:int}")]
        public async Task<IActionResult> Update(int Id)
        {
            return View(db.GetByIdFirst(Id).Data);
        }
        [HttpPost, Route("/Category/Update/{Id:int}")]
        public async Task<IActionResult> Update(int Id,CategoriesDto data)
        {            
            var DataMessage = db.Update(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View(db.GetByIdFirst(Id).Data);
        }
        [Route("/Category/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            db.Delete(Id);
            return RedirectToAction("Index", "Category");
        }
    }
}
