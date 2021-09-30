using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;

namespace Maway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExtrasController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("itemExtras")]
        public async Task<IEnumerable<ExtrasQueryData>> GetItemExtras([FromQuery]GetAvailableExtrasQuery query) => await mediator.Send(query);
    }
}