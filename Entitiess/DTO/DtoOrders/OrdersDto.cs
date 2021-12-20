using Cores.Entities.Abstract;
using System;

namespace Entitiess.DTO
{
    public class OrdersDto:IDTO
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string OdemeTuru { get; set; }
        public decimal CargoPrice { get; set; }

    }
}
