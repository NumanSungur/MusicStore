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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService db;
        public CategoriesController(ICategoriesService _db)
        {
            db = _db;
        }
        [HttpGet]
        public IList<CategoriesDto> Get(int Id)
        {
            return db.GetAll(Id).Data;
        }
        [HttpGet("GetById/{Id}")]
        public CategoriesDto GetById(int Id)
        {
            return db.GetByIdFirst(Id).Data;
        }        
        [HttpPost]
        public IActionResult Post(CategoriesDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, CategoriesDto data)
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
