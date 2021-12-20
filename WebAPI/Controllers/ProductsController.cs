using B.L.Abstract;
using Entitiess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace WebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService db;        
        public ProductsController(IProductsService _db)
        {
            db = _db;            
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IList<ProductsDto> Get()
        {
            return db.GetAll().Data;
        }
        [Authorize(Roles = "Temsilci")]
        [HttpGet("GetById/{Id}")]
        public ProductsUpdateDto GetById(int Id)
        {
            return db.GetById(Id).Data;
        }
        [HttpGet("FiyatınaGore/{Sart}")]
        public IList<ProductsDto> Get(bool Sart)
        {
            if (Sart) 
            {
                return db.GetAll().Data.OrderBy(x => x.Price).ToList();
            }
            else
            {
                return db.GetAll().Data.OrderByDescending(x => x.Price).ToList();
            }
        }        
        [HttpPost]
        public IActionResult Post(ProductsUpdateDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }       
        [HttpPut("{Id}")]
        public IActionResult Put(int Id,ProductsUpdateDto data)
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
