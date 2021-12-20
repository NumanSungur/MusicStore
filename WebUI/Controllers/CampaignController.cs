using B.L.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class CampaignController : Controller
    {
        private readonly IProductsService service;

        public CampaignController(IProductsService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllKampanya());
        }
    }
}
