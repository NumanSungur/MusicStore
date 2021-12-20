using Cores.Entities.Abstract;

namespace Entitiess.DTO
{
    public class PImagesDto: IDTO
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public int ProductsId { get; set; }
    }
}
