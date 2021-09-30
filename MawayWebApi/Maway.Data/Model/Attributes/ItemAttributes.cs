using Maway.Data.Consts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maway.Data.Model
{
    [Table("ItemAttributes", Schema = Schemas.ItemAttributesSchema)]
    public class ItemAttributes : BaseEntity 
    {
        [ForeignKey("ItemTypeId")]
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }
        [ForeignKey("AttributeKey")]
        public string AttributeKey { get; set; }
        public ItemAttribute Attribute { get; set; }
        public string Value { get; set; }

    }
}
