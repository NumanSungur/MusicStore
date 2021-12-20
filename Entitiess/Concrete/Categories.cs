using Cores.Entities.Abstract;
using System.Collections.Generic;

namespace Entitiess.Concrete
{
    public class Categories : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; } 
        public bool Status { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
