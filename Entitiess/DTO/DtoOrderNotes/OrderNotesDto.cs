using Cores.Entities.Abstract;
using System;

namespace Entitiess.DTO
{
    public class OrderNotesDto : IDTO
    {
        public int Id { get; set; }       
        public string Notes { get; set; }        
        public DateTime NotDate { get; set; }
        public int OrdersId { get; set; }
    }
}
