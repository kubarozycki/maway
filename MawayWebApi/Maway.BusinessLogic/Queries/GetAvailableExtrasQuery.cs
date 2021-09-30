using System.Collections.Generic;
using Maway.BusinessLogic.QueryData;
using MediatR;

namespace Maway.BusinessLogic.Queries
{
    public class GetAvailableExtrasQuery : IRequest<IEnumerable<ExtrasQueryData>>
    {
        public int ItemTypeId { get; set; }
    }
}
