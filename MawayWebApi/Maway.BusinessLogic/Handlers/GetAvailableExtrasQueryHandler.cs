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
    public class GetAvailableExtrasQueryHandler : IRequestHandler<GetAvailableExtrasQuery, IEnumerable<ExtrasQueryData>>
    {
        private readonly DatabaseContext databaseContext;
        private readonly IMapper mapper;
        public GetAvailableExtrasQueryHandler(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExtrasQueryData>> Handle(GetAvailableExtrasQuery request, CancellationToken cancellationToken)
        {
            return (await databaseContext.ItemExtras
                .Include(x => x.Extras)
                .Where(x => x.ItemTypeId == request.ItemTypeId)
                .ToListAsync())
                .Select(x =>
              {
                  return new ExtrasQueryData { Id = x.Extras.Id, Price = x.Extras.Price, Name = x.Extras.Name };
              });
        }
    }
}
