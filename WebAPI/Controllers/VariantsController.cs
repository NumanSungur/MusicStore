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
    public class VariantsController : ControllerBase
    {
        private readonly IVariantsService db;
        public VariantsController(IVariantsService _db)
        {
            db = _db;
        }
        [HttpGet]
        public IList<VariantsDto> Get(int Id)
        {
            return db.GetAll(Id).Data;
        }
        [HttpGet("GetById/{Id}")]
        public VariantsDto GetById(int Id)
        {
            return db.GetByIdFirst(Id);
        }
        [HttpPost]
        public IActionResult Post(VariantsDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, VariantsDto data)
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
