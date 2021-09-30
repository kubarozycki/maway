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
    public class AttributesController : ControllerBase
    {
        private readonly IMediator mediator;

        public AttributesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("itemAttributes")]
        public async Task<IEnumerable<ItemAttributesQueryData>> ItemsAttributes([FromQuery]GetItemAttributesQuery query) => await mediator.Send(query);

        [HttpGet("itemAttributes/{itemTypeId}")]
        public async Task<IEnumerable<ItemAttributesQueryData>> GetItemAttributes([FromQuery]GetItemAttributesQuery query) => await mediator.Send(query);
    }
}

