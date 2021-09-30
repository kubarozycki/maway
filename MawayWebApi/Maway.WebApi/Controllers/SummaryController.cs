using System.Threading.Tasks;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : Controller
    {
        private readonly IMediator _mediator;

        public SummaryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("getReservationSummary")]
        public async Task<ReservationSummaryQueryData> GetReservationSummary([FromBody] GetReservationSummaryQuery query) => await _mediator.Send(query);
    }
}