using System.ComponentModel.DataAnnotations.Schema;

namespace Maway.Data.Model
{
    public class ItemPrice : BaseEntity
    {
        public int MinimumDays { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ItemTypeId")]
        public int ItemTypeId { get; set; }
    }
}
