﻿using Cores.Entities.Abstract;
using System;

namespace Entitiess.Concrete
{
    public class OrderInformations:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Sms { get; set; }
        public bool Email { get; set; }
        public string Message { get; set; }
        public DateTime InfoDate { get; set; }
        public int OrdersId { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
