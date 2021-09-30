using System.Collections.Generic;
using Maway.BusinessLogic.QueryData;
using MediatR;

namespace Maway.BusinessLogic.Queries
{
    public class GetItemAttributesQuery : IRequest<IEnumerable<ItemAttributesQueryData>>
    {
        public int? ItemTypeId { get; set; }
    }
}
