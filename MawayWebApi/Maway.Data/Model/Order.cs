using System;
using System.Collections.Generic;

namespace Maway.Data.Model
{
    public class Order : TimeStampedEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Price { get; set; }
        public Item Item { get; set; }
        public ICollection<OrderSupplements> OrderExtras { get; set; }
        public Customer Customer { get; set; }
    }
}
