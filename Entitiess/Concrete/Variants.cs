using Cores.Entities.Abstract;

namespace Entitiess.Concrete
{
    public class Variants:IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; } 
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public int ProductsId { get; set; }     
        public Products Products { get; set; }
    }
}
