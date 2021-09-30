using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;
using Maway.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maway.BusinessLogic.Handlers
{
    public class GetItemAttributesQueryHandler : IRequestHandler<GetItemAttributesQuery, IEnumerable<ItemAttributesQueryData>>
    {
        private readonly DatabaseContext databaseContext;
        private readonly IMapper mapper;

        public GetItemAttributesQueryHandler(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ItemAttributesQueryData>> Handle(GetItemAttributesQuery request, CancellationToken cancellationToken) =>
            await databaseContext.ItemTypes
                .Include(x=>x.ItemAttributes)
                .ThenInclude(x => x.Attribute)
                .Select(x =>mapper.Map<ItemAttributesQueryData>(x))
                .ToListAsync();
    }
}
