using Maway.Data.Consts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maway.Data.Model
{
    [Table("ItemAttribute", Schema = Schemas.ItemAttributesSchema)]
    public class ItemAttribute
    {
        [Key]
        public string Key { get; set; }
        public string Icon { get; set; }
    }
}

