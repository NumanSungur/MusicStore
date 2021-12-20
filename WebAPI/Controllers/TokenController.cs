using Entitiess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.JwtAuthorizeToken.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtAuthService service;
        public TokenController(IJwtAuthService _service)
        {
            service = _service;
        }
        [HttpPost]
        public IActionResult Post(UserApiLoginDto user)
        {
            var Token = service.Authenticate(user.Email, user.Password);
            if (Token == null)
            {
                return BadRequest(Token);
            }
            else
            {
                return Ok(Token);
            }
        }
    }
}
