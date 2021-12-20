﻿using B.L.Abstract;
using Cores.Results.ComplexTypes;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VaryantlarController : Controller
    {
        private readonly IVariantsService db;
        public VaryantlarController(IVariantsService _db)
        {
            db = _db;
        }
        [Route("/Varyantlar/{id:int?}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Data = db.GetAll(id).Data;
            return View();
        }
        [Route("/Varyantlar/{id:int?}")]
        [HttpPost]
        public async Task<IActionResult> Index(int id, [Bind(include: "GroupName,Name,Price")] VariantsDto data)
        {
            data.ProductsId = id;
            var DataMessage = db.Add(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            ViewBag.Data = db.GetAll(id).Data;
            return View();
        }

        [Route("/Varyantlar/delete/{Id:int?}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DataMessage = db.Delete(Id);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return Redirect("/Product");
        }
    }
}
