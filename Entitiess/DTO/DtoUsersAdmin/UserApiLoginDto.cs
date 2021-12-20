using Cores.Entities.Abstract;

namespace Entitiess.DTO 
{
    public class UserApiLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
