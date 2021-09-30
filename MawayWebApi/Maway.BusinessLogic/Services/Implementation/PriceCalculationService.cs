using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maway.BusinessLogic.QueryData;
using Maway.BusinessLogic.Services.Abstract;
using Maway.Data;
using Maway.Data.Model;
using Maway.Data.Model.Supplements;
using Microsoft.EntityFrameworkCore;

namespace Maway.BusinessLogic.Services.Implementation
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public PriceCalculationService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public decimal CalculateItemTypeRentalDailyPrice(DateTime from, DateTime to, int itemTypeId)
        {
            var itemRentalPrices = GetItemRentalPrices(itemTypeId);
            var rentalDaysCount = CalculateRentalDaysCount(from, to);
            var itemRentalDailyPrice = CalculateItemRentalDailyPrice(itemRentalPrices, rentalDaysCount);
            return itemRentalDailyPrice;
        }

        public decimal CalculateRentalPrice(DateTime from, DateTime to, int itemTypeId, IEnumerable<int> extrasId = null)
        {
            var itemRentalPrices = GetItemRentalPrices(itemTypeId);
            var rentalDaysCount = CalculateRentalDaysCount(from, to);
            var itemRentalPrice = CalculateItemRentalDailyPrice(itemRentalPrices, rentalDaysCount) * rentalDaysCount;

            if (extrasId == null)
                return itemRentalPrice;

            var extrasRentalPrice = CalculateExtrasRentalPrice(extrasId);
            return itemRentalPrice + extrasRentalPrice;
        }

        public IEnumerable<ExtrasQueryData> CalculateExtrasPrice(IEnumerable<int> extrasId)
        {
            return _dbContext.Extras
                .Where(x => extrasId.Contains(x.Id))
                .Select(x => _mapper.Map<ExtrasQueryData>(x));
        }

        public int CalculateRentalDaysCount(DateTime from, DateTime to) => (int) (to.Date - from.Date).TotalDays;
        private List<ItemPrice> GetItemRentalPrices(int itemTypeId)=>  _dbContext.ItemTypePrices
            .OrderByDescending(x=>x.MinimumDays)
            .Where(x => x.ItemTypeId == itemTypeId)
            .ToList();

        private decimal CalculateExtrasRentalPrice(IEnumerable<int> extrasId) =>
            _dbContext.Extras
                .Where(x => extrasId.Contains(x.Id))
                .Sum(x => x.Price);

        private decimal CalculateItemRentalDailyPrice(IEnumerable<ItemPrice> itemPrices, int rentalDaysCount)
        {
            var itemPrice = itemPrices.FirstOrDefault(x => x.MinimumDays <= rentalDaysCount);
            return itemPrice?.Price ?? throw new Exception("Couldnt calculate daily rental price");
        }
    }
}