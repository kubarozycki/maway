using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Maway.BusinessLogic.QueryData
{
    public class ItemQueryData
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        public IEnumerable<AttributeQueryData> ItemAttributes { get; set; }

        public decimal DailyPrice { get; set; }
    }
}
