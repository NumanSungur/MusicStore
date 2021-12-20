using B.L.Abstract;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService db;
        public OrdersController(IOrdersService _db)
        {
            db = _db;
        }
        [HttpGet]
        public IList<OrdersDto> Get(string Durum)
        {
            return db.GetAll(Durum).Data;
        }
        [HttpGet("GetById/{Id}")]
        public OrdersUpdateDto GetById(int Id)
        {
            return db.GetById(Id).Data;
        }
        [HttpGet("FiveTableGetAll/{Id}")]
        public IList<OrdersUpdateListDto> FiveTableGetAll(int Id)
        {
            return db.FiveTableGetAll(Id).Data;
        }

        [HttpPost]
        public IActionResult Post(OrdersUpdateDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, OrdersUpdateDto data)
        {
            data.Id = Id;
            db.Update(data);
            return Ok("Başarılı");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            db.Delete(Id);
            return Ok("Başarılı");
        }
    }
}
