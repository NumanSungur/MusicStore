using Cores.Entities.Abstract;

namespace Entitiess.DTO
{
    public class CategoriesDto : IDTO
    {
        public int Id { get; set; }       
        public string Name { get; set; }       
        public int ParentId { get; set; }      
        public bool Status { get; set; }
    }
}
