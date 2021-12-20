using Cores.Entities.Abstract;
using System;

namespace Entitiess.Concrete
{
    public class OrderNotes:IEntity
    {
        public int Id { get; set; }       
        public string Notes { get; set; }
        public DateTime NotDate { get; set; }
        public int OrdersId { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
