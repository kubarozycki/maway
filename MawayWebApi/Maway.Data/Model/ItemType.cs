using Maway.Data.Model.Supplements;
using System.Collections.Generic;

namespace Maway.Data.Model
{
    public class ItemType : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<ItemExtras> ItemExtras { get; set; }
        public ICollection<ItemPrice> ItemPrices { get; set; }
        public ICollection<ItemAttributes> ItemAttributes { get; set; }
    }
}
