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
    public class PImagesController : ControllerBase
    {
        private readonly IPImagesService db;
        public PImagesController(IPImagesService _db)
        {
            db = _db;
        }
        [HttpGet]
        public IList<PImagesDto> Get(int Id)
        {
            return db.GetAll(Id).Data;
        }
        [HttpGet("GetById/{Id}")]
        public PImagesDto GetById(int Id)
        {
            return db.GetByIdFirst(Id).Data;
        }
        [HttpPost]
        public IActionResult Post(PImagesDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, PImagesDto data)
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
