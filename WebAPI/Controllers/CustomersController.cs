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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService db;
        public CustomersController(ICustomersService _db)
        {
            db = _db;
        }
        [HttpGet]
        public IList<CustomersDto> Get()
        {
            return db.GetAll().Data;
        }
        [HttpGet("GetById/{Id}")]
        public CustomersUpdateDto GetById(int Id)
        {
            return db.GetById(Id).Data;
        }
        [HttpGet("Login")]
        public CustomersDto Login(string Email, string Phone, string Password)
        {
            return db.Login(Email,Phone,Password).Data;
        }
        [HttpPost]
        public IActionResult Post(CustomersUpdateDto data)
        {
            db.Add(data);
            return Ok("Başarılı");
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, CustomersUpdateDto data)
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
