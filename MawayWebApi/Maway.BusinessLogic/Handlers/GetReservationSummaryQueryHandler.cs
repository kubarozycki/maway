using System.Threading;
using System.Threading.Tasks;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;
using Maway.BusinessLogic.Services.Abstract;
using Maway.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maway.BusinessLogic.Handlers
{
    public class GetReservationSummaryQueryHandler : IRequestHandler<GetReservationSummaryQuery, ReservationSummaryQueryData>
    {
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly DatabaseContext _dbContext;

        public GetReservationSummaryQueryHandler(IPriceCalculationService priceCalculationService, DatabaseContext dbContext)
        {
            _priceCalculationService = priceCalculationService;
            _dbContext = dbContext;
        }
        public async Task<ReservationSummaryQueryData> Handle(GetReservationSummaryQuery request, CancellationToken cancellationToken)
        {
            return new ReservationSummaryQueryData
            {
                ItemTypeName = (await _dbContext.ItemTypes.FirstOrDefaultAsync(x => x.Id == request.ItemTypeId))?.Title,
                ItemTypeRentalPrice = _priceCalculationService.CalculateRentalPrice(request.From, request.To,request.ItemTypeId),
                OverallPrice = _priceCalculationService.CalculateRentalPrice(request.From, request.To,
                    request.ItemTypeId, request.ExtrasIds),
                Extras = _priceCalculationService.CalculateExtrasPrice(request.ExtrasIds),
                RentalDays = _priceCalculationService.CalculateRentalDaysCount(request.From,request.To)
            };
        }
    }
}