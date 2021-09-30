using System;
using System.Collections.Generic;
using Maway.BusinessLogic.QueryData;
using MediatR;

namespace Maway.BusinessLogic.Queries
{
    public class GetReservationSummaryQuery : IRequest<ReservationSummaryQueryData>
    {
        public int ItemTypeId { get; set; }
        public IEnumerable<int> ExtrasIds { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}