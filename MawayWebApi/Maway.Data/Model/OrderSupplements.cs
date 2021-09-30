using Maway.Data.Model.Supplements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maway.Data.Model
{
    public class OrderSupplements : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ExtrasId { get; set; }
        public ItemExtras Supplements { get; set; }
    }
}
