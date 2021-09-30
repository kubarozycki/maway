using System.Collections.Generic;
using System.Threading.Tasks;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.QueryData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public ItemController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("availableItems")]
        public async Task<IEnumerable<ItemQueryData>> AvailableItems([FromQuery]GetAvailableItemsQuery query) => await mediator.Send(query);
    }
}
