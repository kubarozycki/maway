using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;
using Maway.BusinessLogic.Services.Abstract;
using Maway.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maway.BusinessLogic.Handlers
{
    public class GetAvailableItemsQueryHandler : IRequestHandler<GetAvailableItemsQuery, IEnumerable<ItemQueryData>>
    {
        private readonly DatabaseContext databaseContext;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IMapper mapper;
        public GetAvailableItemsQueryHandler(DatabaseContext databaseContext,IPriceCalculationService priceCalculationService, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            _priceCalculationService = priceCalculationService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ItemQueryData>> Handle(GetAvailableItemsQuery request, CancellationToken cancellationToken) => (await databaseContext.Items
                .Include(x => x.ItemOrders)
                .Include(x=>x.ItemType)
                    // .ThenInclude(x=>x.ItemPrices)
                .Include(x => x.ItemType)
                    .ThenInclude(x => x.ItemAttributes)
                    .ThenInclude(x => x.Attribute)
                .Where(x => !x.ItemOrders.Any(y => y.From >= request.From && request.To <= request.To))
                .Distinct()
                .ToListAsync())
            .Select(x => {
                var itemType = mapper.Map<ItemQueryData>(x.ItemType);
                itemType.DailyPrice = _priceCalculationService.CalculateItemTypeRentalDailyPrice(request.From, request.To, itemType.Id);
                return itemType;
            });
    }
}
