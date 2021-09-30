using System.Collections.Generic;

namespace Maway.BusinessLogic.QueryData
{
    public class ReservationSummaryQueryData
    {
        public IEnumerable<ExtrasQueryData> Extras { get; set; }
        public string ItemTypeName { get; set; }
        public decimal ItemTypeRentalPrice { get; set; }
        public decimal OverallPrice { get; set; }
        public int RentalDays { get; set; }
    }
}