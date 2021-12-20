using Cores.Entities.Abstract;

namespace Entitiess.DTO
{
    public class VariantsDto:IDTO
    {
        public int Id { get; set; }     
        public string GroupName { get; set; }     
        public string Name { get; set; }      
        public decimal Price { get; set; }
        public int ProductsId { get; set; }
    }
}
