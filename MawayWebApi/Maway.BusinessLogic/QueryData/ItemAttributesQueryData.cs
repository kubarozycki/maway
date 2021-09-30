using System.Collections.Generic;

namespace Maway.BusinessLogic.QueryData
{
    public class ItemAttributesQueryData
    {
        public int ItemTypeId { get; set; }
        public IEnumerable<AttributeQueryData> ItemTypeAttributes { get; set; }
    }
}
