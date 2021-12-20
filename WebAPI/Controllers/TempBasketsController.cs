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
    public class TempBasketsController : ControllerBase
    {
        private readonly ITempBasketsService db;
        private readonly IVariantsService vdb;
        public TempBasketsController(ITempBasketsService _db, IVariantsService _vdb)
        {
            db = _db;
            vdb = _vdb;
        }
        [HttpGet]
        public IList<TempBasketsDto> Get(int Id)
        {
            return db.GetAll(Id).Data;
        }
        [HttpGet("GetById/{Id}")]
        public TempBasketsDto GetById(int Id)
        {
            return db.GetById(Id).Data;
        }
        [HttpPost]
        public IActionResult Post(int ProductId, int CookiesID,int VaryantID, TempBasketsDto data)
        {            
            db.AddUpdate(data.ProductsId = ProductId,data.CookiesID=CookiesID, VaryantID == 0 ? 0 : 1 );
            return Ok("Başarılı");
        }
        [HttpPost("SepetArttırEksilt/Id")]
        public IActionResult SepetArttırEksilt(int Id,bool Durum,TempBasketsDto data)
        {

            db.SepetArttırEksilt(data.Id = Id, (Durum == Convert.ToBoolean(0) ? false : true));
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, AutoBasketDto data)
        {
            data.Id = Id;
            db.AutoBasketUpdate(data);
            return Ok("Başarılı");
        }
        [HttpGet("GetByIdAuto/{Id}")]
        public AutoBasketDto GetByIdAuto(int Id)
        {
            return db.GetByIdAuto(Id).Data;
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            db.Delete(Id);
            return Ok("Başarılı");
        }
    }
}
