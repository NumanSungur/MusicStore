using Cores.Entities.Abstract;

namespace Entitiess.DTO
{
    public class ProductsDto : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string MainImages { get; set; }
        public string Explanation { get; set; }       
        public string Description { get; set; }

        public string CallUs { get; set; }
        public string NewsLetters { get; set; }
        public string AboutUs { get; set; }
    }
}
