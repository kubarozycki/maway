using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maway.BusinessLogic.QueryData;

namespace Maway.BusinessLogic.Services.Abstract
{
    public interface IPriceCalculationService
    {
        public decimal CalculateItemTypeRentalDailyPrice(DateTime from, DateTime to, int itemTypeId);
        public decimal CalculateRentalPrice(DateTime from, DateTime to, int itemTypeId, IEnumerable<int> extrasId = null);
        public IEnumerable<ExtrasQueryData> CalculateExtrasPrice(IEnumerable<int> extrasId);
        public int CalculateRentalDaysCount(DateTime from, DateTime to);
    }

    
}