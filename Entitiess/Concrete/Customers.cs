using Cores.Entities.Abstract;
using System.Collections.Generic;

namespace Entitiess.Concrete
{
    public class Customers:IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; } 
        public string Email { get; set; }
        public string City { get; set; } 
        public string District { get; set; } 
        public string FullAddress { get; set; } 
        public string Password { get; set; }
        public bool Advert { get; set; } 
        public bool Gender { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
